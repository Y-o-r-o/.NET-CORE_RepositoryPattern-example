
resource "azurerm_mssql_server" "dev" {
  name                         = var.sql_server_name
  resource_group_name          = var.dev_rg_name
  location                     = var.sql_server_location
  version                      = var.sql_server_version
  administrator_login          = var.sql_admin_login
  administrator_login_password = var.sql_admin_password
}

resource "azurerm_mssql_database" "dev" {
  name        = "RepPatternDB"
  server_id   = azurerm_mssql_server.dev.id
  max_size_gb = 1
  collation   = "SQL_Latin1_General_CP1_CI_AS"
  sku_name    = "Basic"
}

resource "azurerm_mssql_firewall_rule" "local" {
  name             = "FirewallRuleForLocal"
  server_id        = azurerm_mssql_server.dev.id
  start_ip_address = "213.197.163.10"
  end_ip_address   = "213.197.163.10"
}

resource "azurerm_mssql_firewall_rule" "cloud" {
  name             = "FirewallRuleForCloud"
  server_id        = azurerm_mssql_server.dev.id
  start_ip_address = "20.107.224.18"
  end_ip_address   = "20.107.224.18"
}
