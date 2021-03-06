// This code was generated by `SqlHydra.SqlServer` -- v0.810.0.0.
namespace IoTBayAdminApi.Models

type Column(reader: System.Data.IDataReader, getOrdinal: string -> int, column) =
        member __.Name = column
        member __.IsNull() = getOrdinal column |> reader.IsDBNull
        override __.ToString() = __.Name

type RequiredColumn<'T, 'Reader when 'Reader :> System.Data.IDataReader>(reader: 'Reader, getOrdinal, getter: int -> 'T, column) =
        inherit Column(reader, getOrdinal, column)
        member __.Read(?alias) = alias |> Option.defaultValue __.Name |> getOrdinal |> getter

type OptionalColumn<'T, 'Reader when 'Reader :> System.Data.IDataReader>(reader: 'Reader, getOrdinal, getter: int -> 'T, column) =
        inherit Column(reader, getOrdinal, column)
        member __.Read(?alias) = 
            match alias |> Option.defaultValue __.Name |> getOrdinal with
            | o when reader.IsDBNull o -> None
            | o -> Some (getter o)

type RequiredBinaryColumn<'T, 'Reader when 'Reader :> System.Data.IDataReader>(reader: 'Reader, getOrdinal, getValue: int -> obj, column) =
        inherit Column(reader, getOrdinal, column)
        member __.Read(?alias) = alias |> Option.defaultValue __.Name |> getOrdinal |> getValue :?> byte[]

type OptionalBinaryColumn<'T, 'Reader when 'Reader :> System.Data.IDataReader>(reader: 'Reader, getOrdinal, getValue: int -> obj, column) =
        inherit Column(reader, getOrdinal, column)
        member __.Read(?alias) = 
            match alias |> Option.defaultValue __.Name |> getOrdinal with
            | o when reader.IsDBNull o -> None
            | o -> Some (getValue o :?> byte[])
        

module dbo =
    [<CLIMutable>]
    type Categories =
        { Id: int
          Name: string
          Description: string
          ImgUrl: string }

    type CategoriesReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetInt32, "Id")
        member __.Name = RequiredColumn(reader, getOrdinal, reader.GetString, "Name")
        member __.Description = RequiredColumn(reader, getOrdinal, reader.GetString, "Description")
        member __.ImgUrl = RequiredColumn(reader, getOrdinal, reader.GetString, "ImgUrl")

        member __.Read() =
            { Id = __.Id.Read()
              Name = __.Name.Read()
              Description = __.Description.Read()
              ImgUrl = __.ImgUrl.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type Products =
        { Id: int
          Name: string
          Description: string
          ImgUrl: string
          CategoryId: int
          StockLevel: int
          OnOrder: int
          Price: decimal }

    type ProductsReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetInt32, "Id")
        member __.Name = RequiredColumn(reader, getOrdinal, reader.GetString, "Name")
        member __.Description = RequiredColumn(reader, getOrdinal, reader.GetString, "Description")
        member __.ImgUrl = RequiredColumn(reader, getOrdinal, reader.GetString, "ImgUrl")
        member __.CategoryId = RequiredColumn(reader, getOrdinal, reader.GetInt32, "CategoryId")
        member __.StockLevel = RequiredColumn(reader, getOrdinal, reader.GetInt32, "StockLevel")
        member __.OnOrder = RequiredColumn(reader, getOrdinal, reader.GetInt32, "OnOrder")
        member __.Price = RequiredColumn(reader, getOrdinal, reader.GetDecimal, "Price")

        member __.Read() =
            { Id = __.Id.Read()
              Name = __.Name.Read()
              Description = __.Description.Read()
              ImgUrl = __.ImgUrl.Read()
              CategoryId = __.CategoryId.Read()
              StockLevel = __.StockLevel.Read()
              OnOrder = __.OnOrder.Read()
              Price = __.Price.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

type HydraReader(reader: Microsoft.Data.SqlClient.SqlDataReader) =
    let mutable accFieldCount = 0
    let buildGetOrdinal fieldCount =
        let dictionary = 
            [0..reader.FieldCount-1] 
            |> List.map (fun i -> reader.GetName(i), i)
            |> List.sortBy snd
            |> List.skip accFieldCount
            |> List.take fieldCount
            |> dict
        accFieldCount <- accFieldCount + fieldCount
        fun col -> dictionary.Item col
        
    let lazydboCategories = lazy (dbo.CategoriesReader(reader, buildGetOrdinal 4))
    let lazydboProducts = lazy (dbo.ProductsReader(reader, buildGetOrdinal 8))
    member __.``dbo.Categories`` = lazydboCategories.Value
    member __.``dbo.Products`` = lazydboProducts.Value
    member private __.AccFieldCount with get () = accFieldCount and set (value) = accFieldCount <- value

    member private __.GetReaderByName(entity: string, isOption: bool) =
        match entity, isOption with
        | "dbo.Categories", false -> __.``dbo.Categories``.Read >> box
        | "dbo.Categories", true -> __.``dbo.Categories``.ReadIfNotNull >> box
        | "dbo.Products", false -> __.``dbo.Products``.Read >> box
        | "dbo.Products", true -> __.``dbo.Products``.ReadIfNotNull >> box
        | _ -> failwith $"Could not read type '{entity}' because no generated reader exists."

    static member private GetPrimitiveReader(t: System.Type, reader: Microsoft.Data.SqlClient.SqlDataReader, isOpt: bool) =
        let wrap get (ord: int) = 
            if isOpt 
            then (if reader.IsDBNull ord then None else get ord |> Some) |> box 
            else get ord |> box 
        

        if t = typedefof<System.Guid> then Some(wrap reader.GetGuid)
        else if t = typedefof<bool> then Some(wrap reader.GetBoolean)
        else if t = typedefof<int> then Some(wrap reader.GetInt32)
        else if t = typedefof<int64> then Some(wrap reader.GetInt64)
        else if t = typedefof<int16> then Some(wrap reader.GetInt16)
        else if t = typedefof<byte> then Some(wrap reader.GetByte)
        else if t = typedefof<double> then Some(wrap reader.GetDouble)
        else if t = typedefof<System.Single> then Some(wrap reader.GetFloat)
        else if t = typedefof<decimal> then Some(wrap reader.GetDecimal)
        else if t = typedefof<string> then Some(wrap reader.GetString)
        else if t = typedefof<System.DateTimeOffset> then Some(wrap reader.GetDateTimeOffset)
        else if t = typedefof<System.DateOnly> then Some(wrap reader.GetFieldValue)
        else if t = typedefof<System.TimeOnly> then Some(wrap reader.GetFieldValue)
        else if t = typedefof<System.DateTime> then Some(wrap reader.GetDateTime)
        else if t = typedefof<byte []> then Some(wrap reader.GetValue)
        else if t = typedefof<obj> then Some(wrap reader.GetValue)
        else None

    static member Read(reader: Microsoft.Data.SqlClient.SqlDataReader) = 
        let hydra = HydraReader(reader)
                    
        let getOrdinalAndIncrement() = 
            let ordinal = hydra.AccFieldCount
            hydra.AccFieldCount <- hydra.AccFieldCount + 1
            ordinal
            
        let buildEntityReadFn (t: System.Type) = 
            let t, isOpt = 
                if t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<Option<_>> 
                then t.GenericTypeArguments.[0], true
                else t, false
            
            match HydraReader.GetPrimitiveReader(t, reader, isOpt) with
            | Some primitiveReader -> 
                let ord = getOrdinalAndIncrement()
                fun () -> primitiveReader ord
            | None ->
                let nameParts = t.FullName.Split([| '.'; '+' |])
                let schemaAndType = nameParts |> Array.skip (nameParts.Length - 2) |> fun parts -> System.String.Join(".", parts)
                hydra.GetReaderByName(schemaAndType, isOpt)
            
        // Return a fn that will hydrate 'T (which may be a tuple)
        // This fn will be called once per each record returned by the data reader.
        let t = typeof<'T>
        if FSharp.Reflection.FSharpType.IsTuple(t) then
            let readEntityFns = FSharp.Reflection.FSharpType.GetTupleElements(t) |> Array.map buildEntityReadFn
            fun () ->
                let entities = readEntityFns |> Array.map (fun read -> read())
                Microsoft.FSharp.Reflection.FSharpValue.MakeTuple(entities, t) :?> 'T
        else
            let readEntityFn = t |> buildEntityReadFn
            fun () -> 
                readEntityFn() :?> 'T
        
