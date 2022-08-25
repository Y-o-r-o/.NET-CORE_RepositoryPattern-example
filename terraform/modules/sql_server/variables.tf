# azure sql server name
variable "sql_server_name" {
  type = string
}

# azure sql server region
variable "sql_server_location" {
  type = string
}

# azure sql server version
variable "sql_server_version" {
  type = string
}

#db username
variable "sql_admin_login" {
  description = "Database administrator username"
  type        = string
  sensitive   = true
}

#db password
variable "sql_admin_password" {
  description = "Database administrator password"
  type        = string
  sensitive   = true
}

variable "dev_rg_name" {
  description = "tfstate resource group name"
  type = string
}

