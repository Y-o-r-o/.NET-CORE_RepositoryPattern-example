
resource "azurerm_mssql_server" "dev" {
  name                         = var.sql_server_name
  resource_group_name          = var.tfstate_rg_name
  location                     = var.sql_server_location
  version                      = var.sql_server_version
  administrator_login          = var.sql_admin_login
  administrator_login_password = var.sql_admin_password
}