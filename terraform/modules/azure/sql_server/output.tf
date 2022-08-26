output "connection_string" {
  description = "Connection string for the MSSQL Database created."
  value       = "Server=tcp:${azurerm_mssql_server.rep_pattern.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.rep_pattern.name};Persist Security Info=False;User ID=__mssql_server_id__;Password=__mssql_server_password__;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
}