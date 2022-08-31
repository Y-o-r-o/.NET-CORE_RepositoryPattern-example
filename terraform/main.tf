module "resource_group" {
  source = "./modules/resource_group"

  environment = var.environment
  rg_location = var.rg_location
}

module "sql_server" {
  source = "./modules/sql_server"

  # Pass variables to module
  sql_server_name         = var.sql_server_name
  sql_server_location     = var.sql_server_location
  sql_server_version      = var.sql_server_version
  sql_admin_login         = var.sql_admin_login
  sql_admin_password      = var.sql_admin_password
  mssql_db_name           = var.mssql_db_name
  mssql_db_size_gb        = var.mssql_db_size_gb
  mssql_db_collation      = var.mssql_db_collation
  mssql_sku               = var.mssql_sku
  local_firewal_rule_name = var.local_firewal_rule_name
  local_firewal_rule_ip   = var.local_firewal_rule_ip
  cloud_firewal_rule_name = var.cloud_firewal_rule_name
  cloud_firewal_rule_ip   = var.cloud_firewal_rule_ip
  rep_pattern_rg_name      = module.resource_group.rep_pattern_rg_name
}

module "web_app" {
  source = "./modules/web_app"

  # Pass variables to module
  web_app_name           = var.web_app_name
  sku_tier               = var.sku_tier
  os_type                = var.os_type
  rep_pattern_rg_name     = module.resource_group.rep_pattern_rg_name
  rep_pattern_rg_location = module.resource_group.rep_pattern_rg_location
}
