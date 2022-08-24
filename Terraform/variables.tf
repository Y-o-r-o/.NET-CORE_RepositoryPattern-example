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


# azure storage account kind
variable "account_kind" {
  type        = string
  description = "Azure storage account kind"
  default     = "StorageV2"
}

# azure storage account tier
variable "account_tier" {
  type        = string
  description = "Azure storage account tier"
  default     = "Standard"
}

# azure storage account access tier
variable "account_access_tier" {
  type        = string
  description = "Azure storage account access tier"
  default     = "Hot"
}

# azure storage account replication type
variable "account_replication_type" {
  type        = string
  description = "Azure storage account replication type"
  default     = "ZRS"
}

# azure storage account http traffic only option
variable "is_traffic_only" {
  type        = bool
  description = "Azure storage account http traffic only option"
  default     = true
}

# prevent destroy resource group lifecycle
variable "prevent_destroy_rg" {
  type        = bool
  description = "Prevent destroy resource group lifecycle"
  default     = true
}

# prevent destroy storage account lifecycle
variable "prevent_destroy_sa" {
  type        = bool
  description = "Prevent destroy storage account lifecycle"
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
  default     = "development-web-app"
}

# azure sql server name
variable "sql_server_name" {
  type        = string
  description = "Azure sql server name"
  default     = "orionincdevdb"
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