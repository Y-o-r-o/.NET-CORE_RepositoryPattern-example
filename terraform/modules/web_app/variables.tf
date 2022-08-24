# azure web app name
variable "web_app_name" {
  type        = string
  description = "Azure web app name"
  default     = "development-web-app"
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

variable "dev_rg_name" {
  description = "tfstate resource group name"
  type = string
}

variable "dev_rg_location" {
  description = "tfstate resource group location"
  type = string
}