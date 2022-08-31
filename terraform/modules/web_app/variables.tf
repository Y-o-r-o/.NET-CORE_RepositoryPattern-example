variable "environment" {
  type        = string
  description = "This variable defines the environment to be built"
  default     = "Development"
}

# azure web app name
variable "web_app_name" {
  type        = string
  description = "Azure web app name"
  default     = "rep-pattweb-app"
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

variable "rep_pattern_rg_name" {
  description = "tfstate resource group name"
  type        = string
}

variable "rep_pattern_rg_location" {
  description = "tfstate resource group location"
  type        = string
}
