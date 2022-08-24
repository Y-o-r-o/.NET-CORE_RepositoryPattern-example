# azure storage account kind
variable "company" {
  type        = string
  description = "Name of company"
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

# environment
variable "environment" {
  type        = string
  description = "This variable defines the environment to be built"
  default     = "Development"
}

variable "tfstate_rg_name" {
  description = "tfstate resource group name"
  type = string
}

variable "tfstate_rg_location" {
  description = "tfstate resource group location"
  type = string
}

variable "storage_account_depends_on" {
  # the value doesn't matter; we're just using this variable
  # to propagate dependencies.
  type    = any
  default = []
}