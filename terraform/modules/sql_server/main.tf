
resource "azurerm_mssql_server" "repPattern" {
  name                         = var.sql_server_name
  resource_group_name          = var.repPattern_rg_name
  location                     = var.sql_server_location
  version                      = var.sql_server_version
  administrator_login          = var.sql_admin_login
  administrator_login_password = var.sql_admin_password
}

resource "azurerm_mssql_database" "repPattern" {
  name        = var.mssql_db_name
  server_id   = azurerm_mssql_server.repPattern.id
  max_size_gb = var.mssql_db_size_gb
  collation   = var.mssql_db_collation
  sku_name    = var.mssql_sku

}

resource "azurerm_mssql_firewall_rule" "repPattern_local" {
  name             = var.local_firewal_rule_name
  server_id        = azurerm_mssql_server.repPattern.id
  start_ip_address = var.local_firewal_rule_ip
  end_ip_address   = var.local_firewal_rule_ip
}

resource "azurerm_mssql_firewall_rule" "repPattern_cloud" {
  name             = var.cloud_firewal_rule_name
  server_id        = azurerm_mssql_server.repPattern.id
  start_ip_address = var.cloud_firewal_rule_ip
  end_ip_address   = var.cloud_firewal_rule_ip
}