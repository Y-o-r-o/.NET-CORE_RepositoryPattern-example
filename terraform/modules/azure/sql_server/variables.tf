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

variable "rep_pattern_rg_name" {
  description = "tfstate resource group name"
  type        = string
}

variable "mssql_db_name" {
  type    = string
  default = "RepPatternDB"
}

variable "mssql_db_size_gb" {
  description = "ms sql database size in gigabytes"
  type        = number
  default     = "1"
}

variable "mssql_db_collation" {
  description = "specifies the bit patterns that represent each character in a dataset also determine the rules that sort and compare data"
  type        = string
  default     = "SQL_Latin1_General_CP1_CI_AS"
}

variable "mssql_sku" {
  description = "mssql sku"
  type        = string
  default     = "Basic"
}
variable "local_firewal_rule_name" {
  description = "local firewall name"
  type        = string
  default     = "FirewallRuleForLocal"
}

variable "local_firewal_rule_ip" {
  description = "local firewall ip"
  type        = string
  default     = "213.197.163.10"
}

variable "cloud_firewal_rule_name" {
  description = "cloud firewall name"
  type        = string
  default     = "FirewallRuleForCloud"
}
variable "cloud_firewal_rule_ip" {
  description = "cloud firewall ip"
  type        = string
  default     = "20.107.224.17"
}


