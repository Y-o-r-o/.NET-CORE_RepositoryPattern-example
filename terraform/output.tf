output "repPattern_web_app_name" {
  value = module.web_app.repPattern_web_app_name
}

output "connection_string" {
  description = "Connection string for the MSSQL Database created."
  value       = module.sql_server.connection_string
}
