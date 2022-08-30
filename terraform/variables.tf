# company
variable "company" {
  type        = string
  description = "This variable defines the name of the company"
  default     = "TestInc"
}

# environment
variable "environment" {
  type        = string
  description = "This variable defines the environment to be built"
  default     = "Development"
}

# azure region
variable "rg_location" {
  type        = string
  description = "Azure region where the resource group will be created"
  default     = "north europe"
}

# prevent destroy resource group lifecycle
variable "prevent_destroy_rg" {
  type        = bool
  description = "Prevent destroy resource group lifecycle"
  default     = true
}

# azure service plan sku tier
variable "sku_tier" {
  type        = string
  description = "Azure service plan sku tier"
  default     = "F1"
}

# azure service plan OS
variable "os_type" {
  type        = string
  description = "Azure service plan OS"
  default     = "Windows"
}


# azure web app name
variable "web_app_name" {
  type        = string
  description = "Azure web app name"
  default     = "web-app"
}

# azure sql server name
variable "sql_server_name" {
  type        = string
  description = "Azure sql server name"
  default     = "my-sql-server"
}

# azure sql server region
variable "sql_server_location" {
  type        = string
  description = "Azure region where the sql server will be created"
  default     = "west europe"
}

# azure sql server version
variable "sql_server_version" {
  type        = string
  description = "Azure sql server version"
  default     = "12.0"
}

# db username
variable "sql_admin_login" {
  description = "Database administrator username"
  type        = string
  sensitive   = true
}

# db password
variable "sql_admin_password" {
  description = "Database administrator password"
  type        = string
  sensitive   = true
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
  default     = "20.107.224.18"
}


