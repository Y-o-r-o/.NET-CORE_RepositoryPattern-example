module "resource_group" {
  source = "./modules/resource_group"

  environment = var.environment
  rg_location = var.rg_location
}

module "sql_server" {
  source = "./modules/sql_server"

  # Pass variables to module
  sql_server_name     = var.sql_server_name
  sql_server_location = var.sql_server_location
  sql_server_version  = var.sql_server_version
  sql_admin_login     = var.sql_admin_login
  sql_admin_password  = var.sql_admin_password
  dev_rg_name        = module.resource_group.dev_rg_name
}

module "web_app" {
  source = "./modules/web_app"

  # Pass variables to module
  web_app_name    = var.web_app_name
  sku_tier        = var.sku_tier
  os_type         = var.os_type
  dev_rg_name     = module.resource_group.dev_rg_name
  dev_rg_location = module.resource_group.dev_rg_location
}
