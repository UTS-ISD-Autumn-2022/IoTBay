namespace IoTBayAdminApi

module HttpHandlers =

    open Microsoft.AspNetCore.Http
    open Microsoft.Data.SqlClient
    open FSharp.Control.Tasks
    open Giraffe
    open SqlHydra.Query
    open SqlKata.Compilers
    open IoTBayAdminApi.Models

    let categoriesTable = table<dbo.Categories> |> inSchema (nameof dbo)
    let productsTable = table<dbo.Products> |> inSchema (nameof dbo)

    let openConn =
        let connectStr =
            "Server=34.151.96.119; Database=iotbaydb-test; User Id=sqlserver; Password=ekvkdK2%^8; TrustServerCertificate=True"

        let conn = new SqlConnection(connectStr)
        conn.Open()
        conn

    let openCtx () =
        let compiler = SqlServerCompiler()
        let conn = openConn
        new QueryContext(conn, compiler)

    let handleGetCategories =
        fun (next: HttpFunc) (ctx: HttpContext) ->
            task {
                let! categories =
                    selectTask HydraReader.Read (Create openCtx) {
                        for c in categoriesTable do
                            select (c.Id, c.Name, c.Description, c.ImgUrl) into selected

                            mapSeq (
                                let _id, _name, _desc, _imgurl = selected

                                { Id = _id
                                  Name = _name
                                  Description = _desc
                                  ImgUrl = _imgurl }: dbo.Categories

                            )
                    }

                return! json categories next ctx
            }

    let categoriesRoutes: HttpHandler =
        GET
        >=> (route "/categories" >=> handleGetCategories)

    let handleGetProducts =
        fun (next: HttpFunc) (ctx: HttpContext) ->
            task {
                let! products =
                    selectTask HydraReader.Read (Create openCtx) {
                        for p in productsTable do
                            select
                                (p.Id, p.Name, p.Description, p.CategoryId, p.ImgUrl, p.StockLevel, p.OnOrder, p.Price)
                                into
                                selected

                            mapSeq (
                                let _id, _name, _desc, _catid, _imgurl, _stk, _ord, _prc = selected

                                { Id = _id
                                  Name = _name
                                  Description = _desc
                                  CategoryId = _catid
                                  ImgUrl = _imgurl
                                  StockLevel = _stk
                                  OnOrder = _ord
                                  Price = _prc }: dbo.Products
                            )
                    }

                return! json products next ctx
            }

    let productsRoutes: HttpHandler = GET >=> (route "/products" >=> handleGetProducts)
