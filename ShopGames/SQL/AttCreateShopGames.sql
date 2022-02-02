--SQL Server

CREATE TABLE [Client] (
	id_client integer NOT NULL IDENTITY(1,1),
	nm_client varchar(100) NOT NULL,
	nm_mail varchar(100) NOT NULL UNIQUE,
	vl_cpf varchar(14) NOT NULL UNIQUE,
	nm_nick varchar(20) NOT NULL,
	vl_password varchar(255) NOT NULL,
	dt_registration datetime NOT NULL,
	fl_active integer NOT NULL DEFAULT 1,
  CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED
  (
  [id_client] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Library_User] (
	id_library integer NOT NULL IDENTITY(1,1),
	id_client integer NOT NULL,
	id_product integer NOT NULL,
	dt_registration datetime NOT NULL,
  CONSTRAINT [PK_LIBRARY_USER] PRIMARY KEY CLUSTERED
  (
  [id_library] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Product] (
	id_product integer NOT NULL IDENTITY(1,1),
	vl_price decimal(19,4) NOT NULL,
	nm_product varchar(50) NOT NULL UNIQUE,
	vl_discount decimal(19,4),
	vl_prodcount integer NOT NULL,
	ds_text varchar(250) NOT NULL,
	vl_avaliation integer NOT NULL,
	id_developer integer NOT NULL,
	id_provider integer NOT NULL,
	id_category integer NOT NULL,
	dt_launcher datetime NOT NULL,
	fl_active integer NOT NULL DEFAULT 1,
  CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED
  (
  [id_product] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [System_Requirement] (
	id_system_requirement integer NOT NULL IDENTITY(1,1),
	nm_required varchar(100) NOT NULL UNIQUE,
	fl_active integer NOT NULL DEFAULT 1,
  CONSTRAINT [PK_SYSTEM_REQUIREMENT] PRIMARY KEY CLUSTERED
  (
  [id_system_requirement] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Product_System_Req] (
	id_product_system_req integer NOT NULL IDENTITY(1,1),
	id_product integer NOT NULL,
	id_system_requirement integer NOT NULL,
  CONSTRAINT [PK_PRODUCT_SYSTEM_REQ] PRIMARY KEY CLUSTERED
  (
  [id_product_system_req] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Enterprise] (
	id_enterprise integer NOT NULL IDENTITY(1,1),
	nm_enterprise varchar(255) NOT NULL,
	fl_active integer NOT NULL DEFAULT 1,
  CONSTRAINT [PK_ENTERPRISE] PRIMARY KEY CLUSTERED
  (
  [id_enterprise] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Shopping_Cart] (
	id_shop integer NOT NULL IDENTITY(1,1),
	id_client integer NOT NULL,
	id_product integer NOT NULL,
	fl_situation integer NOT NULL,
  CONSTRAINT [PK_SHOPPING_CART] PRIMARY KEY CLUSTERED
  (
  [id_shop] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Category] (
	id_category integer NOT NULL IDENTITY(1,1),
	nm_category varchar(255) NOT NULL,
	fl_active integer NOT NULL DEFAULT 1,
  CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED
  (
  [id_category] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [Library_User] WITH CHECK ADD CONSTRAINT [Library_User_fk0] FOREIGN KEY ([id_client]) REFERENCES [Client]([id_client])
GO
ALTER TABLE [Library_User] CHECK CONSTRAINT [Library_User_fk0]
GO
ALTER TABLE [Library_User] WITH CHECK ADD CONSTRAINT [Library_User_fk1] FOREIGN KEY ([id_product]) REFERENCES [Product]([id_product])
GO
ALTER TABLE [Library_User] CHECK CONSTRAINT [Library_User_fk1]
GO
ALTER TABLE [Product] WITH CHECK ADD CONSTRAINT [Product_fk0] FOREIGN KEY ([id_developer]) REFERENCES [Enterprise]([id_enterprise])
GO
ALTER TABLE [Product] CHECK CONSTRAINT [Product_fk0]
GO
ALTER TABLE [Product] WITH CHECK ADD CONSTRAINT [Product_fk1] FOREIGN KEY ([id_provider]) REFERENCES [Enterprise]([id_enterprise])
GO
ALTER TABLE [Product] CHECK CONSTRAINT [Product_fk1]
GO
ALTER TABLE [Product] WITH CHECK ADD CONSTRAINT [Product_fk2] FOREIGN KEY ([id_category]) REFERENCES [Category]([id_category])
GO
ALTER TABLE [Product] CHECK CONSTRAINT [Product_fk2]
GO
ALTER TABLE [Product_System_Req] WITH CHECK ADD CONSTRAINT [Product_System_Req_fk0] FOREIGN KEY ([id_product]) REFERENCES [Product]([id_product])
GO
ALTER TABLE [Product_System_Req] CHECK CONSTRAINT [Product_System_Req_fk0]
GO
ALTER TABLE [Product_System_Req] WITH CHECK ADD CONSTRAINT [Product_System_Req_fk1] FOREIGN KEY ([id_system_requirement]) REFERENCES [System_Requirement]([id_system_requirement])
GO
ALTER TABLE [Product_System_Req] CHECK CONSTRAINT [Product_System_Req_fk1]
GO
ALTER TABLE [Shopping_Cart] WITH CHECK ADD CONSTRAINT [Shopping_Cart_fk0] FOREIGN KEY ([id_client]) REFERENCES [Client]([id_client])
GO
ALTER TABLE [Shopping_Cart] CHECK CONSTRAINT [Shopping_Cart_fk0]
GO
ALTER TABLE [Shopping_Cart] WITH CHECK ADD CONSTRAINT [Shopping_Cart_fk1] FOREIGN KEY ([id_product]) REFERENCES [Product]([id_product])
GO
ALTER TABLE [Shopping_Cart] CHECK CONSTRAINT [Shopping_Cart_fk1]
GO