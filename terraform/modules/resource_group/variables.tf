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

# company
variable "company" {
  type        = string
  description = "This variable defines the name of the company"
  default     = "TestInc"
}
