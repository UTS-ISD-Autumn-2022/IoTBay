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
    type AspNetRoleClaims =
        { Id: int
          RoleId: string
          ClaimType: Option<string>
          ClaimValue: Option<string> }

    type AspNetRoleClaimsReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetInt32, "Id")
        member __.RoleId = RequiredColumn(reader, getOrdinal, reader.GetString, "RoleId")
        member __.ClaimType = OptionalColumn(reader, getOrdinal, reader.GetString, "ClaimType")
        member __.ClaimValue = OptionalColumn(reader, getOrdinal, reader.GetString, "ClaimValue")

        member __.Read() =
            { Id = __.Id.Read()
              RoleId = __.RoleId.Read()
              ClaimType = __.ClaimType.Read()
              ClaimValue = __.ClaimValue.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type AspNetRoles =
        { Id: string
          Name: Option<string>
          NormalizedName: Option<string>
          ConcurrencyStamp: Option<string> }

    type AspNetRolesReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetString, "Id")
        member __.Name = OptionalColumn(reader, getOrdinal, reader.GetString, "Name")
        member __.NormalizedName = OptionalColumn(reader, getOrdinal, reader.GetString, "NormalizedName")
        member __.ConcurrencyStamp = OptionalColumn(reader, getOrdinal, reader.GetString, "ConcurrencyStamp")

        member __.Read() =
            { Id = __.Id.Read()
              Name = __.Name.Read()
              NormalizedName = __.NormalizedName.Read()
              ConcurrencyStamp = __.ConcurrencyStamp.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type AspNetUserClaims =
        { Id: int
          UserId: string
          ClaimType: Option<string>
          ClaimValue: Option<string> }

    type AspNetUserClaimsReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetInt32, "Id")
        member __.UserId = RequiredColumn(reader, getOrdinal, reader.GetString, "UserId")
        member __.ClaimType = OptionalColumn(reader, getOrdinal, reader.GetString, "ClaimType")
        member __.ClaimValue = OptionalColumn(reader, getOrdinal, reader.GetString, "ClaimValue")

        member __.Read() =
            { Id = __.Id.Read()
              UserId = __.UserId.Read()
              ClaimType = __.ClaimType.Read()
              ClaimValue = __.ClaimValue.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type AspNetUserLogins =
        { LoginProvider: string
          ProviderKey: string
          ProviderDisplayName: Option<string>
          UserId: string }

    type AspNetUserLoginsReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.LoginProvider = RequiredColumn(reader, getOrdinal, reader.GetString, "LoginProvider")
        member __.ProviderKey = RequiredColumn(reader, getOrdinal, reader.GetString, "ProviderKey")
        member __.ProviderDisplayName = OptionalColumn(reader, getOrdinal, reader.GetString, "ProviderDisplayName")
        member __.UserId = RequiredColumn(reader, getOrdinal, reader.GetString, "UserId")

        member __.Read() =
            { LoginProvider = __.LoginProvider.Read()
              ProviderKey = __.ProviderKey.Read()
              ProviderDisplayName = __.ProviderDisplayName.Read()
              UserId = __.UserId.Read() }

        member __.ReadIfNotNull() =
            if __.LoginProvider.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type AspNetUserRoles = { UserId: string; RoleId: string }

    type AspNetUserRolesReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.UserId = RequiredColumn(reader, getOrdinal, reader.GetString, "UserId")
        member __.RoleId = RequiredColumn(reader, getOrdinal, reader.GetString, "RoleId")

        member __.Read() =
            { UserId = __.UserId.Read()
              RoleId = __.RoleId.Read() }

        member __.ReadIfNotNull() =
            if __.UserId.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type AspNetUserTokens =
        { UserId: string
          LoginProvider: string
          Name: string
          Value: Option<string> }

    type AspNetUserTokensReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.UserId = RequiredColumn(reader, getOrdinal, reader.GetString, "UserId")
        member __.LoginProvider = RequiredColumn(reader, getOrdinal, reader.GetString, "LoginProvider")
        member __.Name = RequiredColumn(reader, getOrdinal, reader.GetString, "Name")
        member __.Value = OptionalColumn(reader, getOrdinal, reader.GetString, "Value")

        member __.Read() =
            { UserId = __.UserId.Read()
              LoginProvider = __.LoginProvider.Read()
              Name = __.Name.Read()
              Value = __.Value.Read() }

        member __.ReadIfNotNull() =
            if __.UserId.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type AspNetUsers =
        { Id: string
          UserName: Option<string>
          NormalizedUserName: Option<string>
          Email: Option<string>
          NormalizedEmail: Option<string>
          EmailConfirmed: bool
          PasswordHash: Option<string>
          SecurityStamp: Option<string>
          ConcurrencyStamp: Option<string>
          PhoneNumber: Option<string>
          PhoneNumberConfirmed: bool
          TwoFactorEnabled: bool
          LockoutEnd: Option<System.DateTimeOffset>
          LockoutEnabled: bool
          AccessFailedCount: int }

    type AspNetUsersReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetString, "Id")
        member __.UserName = OptionalColumn(reader, getOrdinal, reader.GetString, "UserName")
        member __.NormalizedUserName = OptionalColumn(reader, getOrdinal, reader.GetString, "NormalizedUserName")
        member __.Email = OptionalColumn(reader, getOrdinal, reader.GetString, "Email")
        member __.NormalizedEmail = OptionalColumn(reader, getOrdinal, reader.GetString, "NormalizedEmail")
        member __.EmailConfirmed = RequiredColumn(reader, getOrdinal, reader.GetBoolean, "EmailConfirmed")
        member __.PasswordHash = OptionalColumn(reader, getOrdinal, reader.GetString, "PasswordHash")
        member __.SecurityStamp = OptionalColumn(reader, getOrdinal, reader.GetString, "SecurityStamp")
        member __.ConcurrencyStamp = OptionalColumn(reader, getOrdinal, reader.GetString, "ConcurrencyStamp")
        member __.PhoneNumber = OptionalColumn(reader, getOrdinal, reader.GetString, "PhoneNumber")
        member __.PhoneNumberConfirmed = RequiredColumn(reader, getOrdinal, reader.GetBoolean, "PhoneNumberConfirmed")
        member __.TwoFactorEnabled = RequiredColumn(reader, getOrdinal, reader.GetBoolean, "TwoFactorEnabled")
        member __.LockoutEnd = OptionalColumn(reader, getOrdinal, reader.GetDateTimeOffset, "LockoutEnd")
        member __.LockoutEnabled = RequiredColumn(reader, getOrdinal, reader.GetBoolean, "LockoutEnabled")
        member __.AccessFailedCount = RequiredColumn(reader, getOrdinal, reader.GetInt32, "AccessFailedCount")

        member __.Read() =
            { Id = __.Id.Read()
              UserName = __.UserName.Read()
              NormalizedUserName = __.NormalizedUserName.Read()
              Email = __.Email.Read()
              NormalizedEmail = __.NormalizedEmail.Read()
              EmailConfirmed = __.EmailConfirmed.Read()
              PasswordHash = __.PasswordHash.Read()
              SecurityStamp = __.SecurityStamp.Read()
              ConcurrencyStamp = __.ConcurrencyStamp.Read()
              PhoneNumber = __.PhoneNumber.Read()
              PhoneNumberConfirmed = __.PhoneNumberConfirmed.Read()
              TwoFactorEnabled = __.TwoFactorEnabled.Read()
              LockoutEnd = __.LockoutEnd.Read()
              LockoutEnabled = __.LockoutEnabled.Read()
              AccessFailedCount = __.AccessFailedCount.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

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
    type Customers =
        { Id: System.Guid
          LoginCredentialsId: string
          Address: string }

    type CustomersReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetGuid, "Id")
        member __.LoginCredentialsId = RequiredColumn(reader, getOrdinal, reader.GetString, "LoginCredentialsId")
        member __.Address = RequiredColumn(reader, getOrdinal, reader.GetString, "Address")

        member __.Read() =
            { Id = __.Id.Read()
              LoginCredentialsId = __.LoginCredentialsId.Read()
              Address = __.Address.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type Employees =
        { Id: System.Guid
          Position: string
          LoginCredentialsId: string
          Department: string }

    type EmployeesReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetGuid, "Id")
        member __.Position = RequiredColumn(reader, getOrdinal, reader.GetString, "Position")
        member __.LoginCredentialsId = RequiredColumn(reader, getOrdinal, reader.GetString, "LoginCredentialsId")
        member __.Department = RequiredColumn(reader, getOrdinal, reader.GetString, "Department")

        member __.Read() =
            { Id = __.Id.Read()
              Position = __.Position.Read()
              LoginCredentialsId = __.LoginCredentialsId.Read()
              Department = __.Department.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type OrderProduct = { OrdersId: int; ProductsId: int }

    type OrderProductReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.OrdersId = RequiredColumn(reader, getOrdinal, reader.GetInt32, "OrdersId")
        member __.ProductsId = RequiredColumn(reader, getOrdinal, reader.GetInt32, "ProductsId")

        member __.Read() =
            { OrdersId = __.OrdersId.Read()
              ProductsId = __.ProductsId.Read() }

        member __.ReadIfNotNull() =
            if __.OrdersId.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type Orders =
        { Id: int
          Address: string
          DeliveryInstructions: string
          DateOrdered: System.DateTime
          LastUpdate: System.DateTime
          Status: int
          CustomerId: Option<System.Guid> }

    type OrdersReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetInt32, "Id")
        member __.Address = RequiredColumn(reader, getOrdinal, reader.GetString, "Address")
        member __.DeliveryInstructions = RequiredColumn(reader, getOrdinal, reader.GetString, "DeliveryInstructions")
        member __.DateOrdered = RequiredColumn(reader, getOrdinal, reader.GetDateTime, "DateOrdered")
        member __.LastUpdate = RequiredColumn(reader, getOrdinal, reader.GetDateTime, "LastUpdate")
        member __.Status = RequiredColumn(reader, getOrdinal, reader.GetInt32, "Status")
        member __.CustomerId = OptionalColumn(reader, getOrdinal, reader.GetGuid, "CustomerId")

        member __.Read() =
            { Id = __.Id.Read()
              Address = __.Address.Read()
              DeliveryInstructions = __.DeliveryInstructions.Read()
              DateOrdered = __.DateOrdered.Read()
              LastUpdate = __.LastUpdate.Read()
              Status = __.Status.Read()
              CustomerId = __.CustomerId.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type PaymentDetails =
        { Id: System.Guid
          CardName: string
          CardNumber: decimal
          CardCvc: decimal
          ExpiryMonth: decimal
          ExpiryYear: decimal
          CustomerId: System.Guid }

    type PaymentDetailsReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetGuid, "Id")
        member __.CardName = RequiredColumn(reader, getOrdinal, reader.GetString, "CardName")
        member __.CardNumber = RequiredColumn(reader, getOrdinal, reader.GetDecimal, "CardNumber")
        member __.CardCvc = RequiredColumn(reader, getOrdinal, reader.GetDecimal, "CardCvc")
        member __.ExpiryMonth = RequiredColumn(reader, getOrdinal, reader.GetDecimal, "ExpiryMonth")
        member __.ExpiryYear = RequiredColumn(reader, getOrdinal, reader.GetDecimal, "ExpiryYear")
        member __.CustomerId = RequiredColumn(reader, getOrdinal, reader.GetGuid, "CustomerId")

        member __.Read() =
            { Id = __.Id.Read()
              CardName = __.CardName.Read()
              CardNumber = __.CardNumber.Read()
              CardCvc = __.CardCvc.Read()
              ExpiryMonth = __.ExpiryMonth.Read()
              ExpiryYear = __.ExpiryYear.Read()
              CustomerId = __.CustomerId.Read() }

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

    [<CLIMutable>]
    type Reviews =
        { Id: int
          ReviewContent: string
          CustomerId: System.Guid
          ProductId: int }

    type ReviewsReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.Id = RequiredColumn(reader, getOrdinal, reader.GetInt32, "Id")
        member __.ReviewContent = RequiredColumn(reader, getOrdinal, reader.GetString, "ReviewContent")
        member __.CustomerId = RequiredColumn(reader, getOrdinal, reader.GetGuid, "CustomerId")
        member __.ProductId = RequiredColumn(reader, getOrdinal, reader.GetInt32, "ProductId")

        member __.Read() =
            { Id = __.Id.Read()
              ReviewContent = __.ReviewContent.Read()
              CustomerId = __.CustomerId.Read()
              ProductId = __.ProductId.Read() }

        member __.ReadIfNotNull() =
            if __.Id.IsNull() then None else Some(__.Read())

    [<CLIMutable>]
    type __EFMigrationsHistory =
        { MigrationId: string
          ProductVersion: string }

    type __EFMigrationsHistoryReader(reader: Microsoft.Data.SqlClient.SqlDataReader, getOrdinal) =
        member __.MigrationId = RequiredColumn(reader, getOrdinal, reader.GetString, "MigrationId")
        member __.ProductVersion = RequiredColumn(reader, getOrdinal, reader.GetString, "ProductVersion")

        member __.Read() =
            { MigrationId = __.MigrationId.Read()
              ProductVersion = __.ProductVersion.Read() }

        member __.ReadIfNotNull() =
            if __.MigrationId.IsNull() then None else Some(__.Read())

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
        
    let lazydboAspNetRoleClaims = lazy (dbo.AspNetRoleClaimsReader(reader, buildGetOrdinal 4))
    let lazydboAspNetRoles = lazy (dbo.AspNetRolesReader(reader, buildGetOrdinal 4))
    let lazydboAspNetUserClaims = lazy (dbo.AspNetUserClaimsReader(reader, buildGetOrdinal 4))
    let lazydboAspNetUserLogins = lazy (dbo.AspNetUserLoginsReader(reader, buildGetOrdinal 4))
    let lazydboAspNetUserRoles = lazy (dbo.AspNetUserRolesReader(reader, buildGetOrdinal 2))
    let lazydboAspNetUserTokens = lazy (dbo.AspNetUserTokensReader(reader, buildGetOrdinal 4))
    let lazydboAspNetUsers = lazy (dbo.AspNetUsersReader(reader, buildGetOrdinal 15))
    let lazydboCategories = lazy (dbo.CategoriesReader(reader, buildGetOrdinal 4))
    let lazydboCustomers = lazy (dbo.CustomersReader(reader, buildGetOrdinal 3))
    let lazydboEmployees = lazy (dbo.EmployeesReader(reader, buildGetOrdinal 4))
    let lazydboOrderProduct = lazy (dbo.OrderProductReader(reader, buildGetOrdinal 2))
    let lazydboOrders = lazy (dbo.OrdersReader(reader, buildGetOrdinal 7))
    let lazydboPaymentDetails = lazy (dbo.PaymentDetailsReader(reader, buildGetOrdinal 7))
    let lazydboProducts = lazy (dbo.ProductsReader(reader, buildGetOrdinal 8))
    let lazydboReviews = lazy (dbo.ReviewsReader(reader, buildGetOrdinal 4))
    let lazydbo__EFMigrationsHistory = lazy (dbo.__EFMigrationsHistoryReader (reader, buildGetOrdinal 2))
    member __.``dbo.AspNetRoleClaims`` = lazydboAspNetRoleClaims.Value
    member __.``dbo.AspNetRoles`` = lazydboAspNetRoles.Value
    member __.``dbo.AspNetUserClaims`` = lazydboAspNetUserClaims.Value
    member __.``dbo.AspNetUserLogins`` = lazydboAspNetUserLogins.Value
    member __.``dbo.AspNetUserRoles`` = lazydboAspNetUserRoles.Value
    member __.``dbo.AspNetUserTokens`` = lazydboAspNetUserTokens.Value
    member __.``dbo.AspNetUsers`` = lazydboAspNetUsers.Value
    member __.``dbo.Categories`` = lazydboCategories.Value
    member __.``dbo.Customers`` = lazydboCustomers.Value
    member __.``dbo.Employees`` = lazydboEmployees.Value
    member __.``dbo.OrderProduct`` = lazydboOrderProduct.Value
    member __.``dbo.Orders`` = lazydboOrders.Value
    member __.``dbo.PaymentDetails`` = lazydboPaymentDetails.Value
    member __.``dbo.Products`` = lazydboProducts.Value
    member __.``dbo.Reviews`` = lazydboReviews.Value
    member __.``dbo.__EFMigrationsHistory`` = lazydbo__EFMigrationsHistory.Value
    member private __.AccFieldCount with get () = accFieldCount and set (value) = accFieldCount <- value

    member private __.GetReaderByName(entity: string, isOption: bool) =
        match entity, isOption with
        | "dbo.AspNetRoleClaims", false -> __.``dbo.AspNetRoleClaims``.Read >> box
        | "dbo.AspNetRoleClaims", true -> __.``dbo.AspNetRoleClaims``.ReadIfNotNull >> box
        | "dbo.AspNetRoles", false -> __.``dbo.AspNetRoles``.Read >> box
        | "dbo.AspNetRoles", true -> __.``dbo.AspNetRoles``.ReadIfNotNull >> box
        | "dbo.AspNetUserClaims", false -> __.``dbo.AspNetUserClaims``.Read >> box
        | "dbo.AspNetUserClaims", true -> __.``dbo.AspNetUserClaims``.ReadIfNotNull >> box
        | "dbo.AspNetUserLogins", false -> __.``dbo.AspNetUserLogins``.Read >> box
        | "dbo.AspNetUserLogins", true -> __.``dbo.AspNetUserLogins``.ReadIfNotNull >> box
        | "dbo.AspNetUserRoles", false -> __.``dbo.AspNetUserRoles``.Read >> box
        | "dbo.AspNetUserRoles", true -> __.``dbo.AspNetUserRoles``.ReadIfNotNull >> box
        | "dbo.AspNetUserTokens", false -> __.``dbo.AspNetUserTokens``.Read >> box
        | "dbo.AspNetUserTokens", true -> __.``dbo.AspNetUserTokens``.ReadIfNotNull >> box
        | "dbo.AspNetUsers", false -> __.``dbo.AspNetUsers``.Read >> box
        | "dbo.AspNetUsers", true -> __.``dbo.AspNetUsers``.ReadIfNotNull >> box
        | "dbo.Categories", false -> __.``dbo.Categories``.Read >> box
        | "dbo.Categories", true -> __.``dbo.Categories``.ReadIfNotNull >> box
        | "dbo.Customers", false -> __.``dbo.Customers``.Read >> box
        | "dbo.Customers", true -> __.``dbo.Customers``.ReadIfNotNull >> box
        | "dbo.Employees", false -> __.``dbo.Employees``.Read >> box
        | "dbo.Employees", true -> __.``dbo.Employees``.ReadIfNotNull >> box
        | "dbo.OrderProduct", false -> __.``dbo.OrderProduct``.Read >> box
        | "dbo.OrderProduct", true -> __.``dbo.OrderProduct``.ReadIfNotNull >> box
        | "dbo.Orders", false -> __.``dbo.Orders``.Read >> box
        | "dbo.Orders", true -> __.``dbo.Orders``.ReadIfNotNull >> box
        | "dbo.PaymentDetails", false -> __.``dbo.PaymentDetails``.Read >> box
        | "dbo.PaymentDetails", true -> __.``dbo.PaymentDetails``.ReadIfNotNull >> box
        | "dbo.Products", false -> __.``dbo.Products``.Read >> box
        | "dbo.Products", true -> __.``dbo.Products``.ReadIfNotNull >> box
        | "dbo.Reviews", false -> __.``dbo.Reviews``.Read >> box
        | "dbo.Reviews", true -> __.``dbo.Reviews``.ReadIfNotNull >> box
        | "dbo.__EFMigrationsHistory", false -> __.``dbo.__EFMigrationsHistory``.Read >> box
        | "dbo.__EFMigrationsHistory", true -> __.``dbo.__EFMigrationsHistory``.ReadIfNotNull >> box
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
        
