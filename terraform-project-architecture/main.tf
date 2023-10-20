terraform {
  required_providers {
    docker = {
      source  = "kreuzwerker/docker"
      version = "~> 3.0.1"
    }
  }
}

provider "docker" {}

resource "docker_image" "aspnet" {
  name         = "mcr.microsoft.com/dotnet/samples:aspnetapp"
  keep_locally = false
}

resource "docker_image" "postgres" {
  name         = "postgres:latest"
  keep_locally = false
}

resource "docker_image" "rabbitmq" {
  name         = "rabbitmq:management"
  keep_locally = false
}

resource "docker_container" "api_gateway" {
  image = docker_image.aspnet.image_id
  name  = "api_gateway"
  ports {
    internal = 8080
    external = 5001
  }
}

resource "docker_container" "msc_identity" {
  image = docker_image.aspnet.image_id
  name  = "msc_identity"
  ports {
    internal = 8080
    external = 5002
  }
}

resource "docker_container" "msc_members" {
  image = docker_image.aspnet.image_id
  name  = "msc_members"
  ports {
    internal = 8080
    external = 5003
  }
}

resource "docker_container" "msc_bookings" {
  image = docker_image.aspnet.image_id
  name  = "msc_bookings"
  ports {
    internal = 8080
    external = 5004
  }
}

resource "docker_container" "msc_highlights" {
  image = docker_image.aspnet.image_id
  name  = "msc_highlights"
  ports {
    internal = 8080
    external = 5005
  }
}

resource "docker_container" "msc_notifications" {
  image = docker_image.aspnet.image_id
  name  = "msc_notifications"
  ports {
    internal = 8080
    external = 5006
  }
}

resource "docker_container" "db_msc_identity" {
  image = docker_image.postgres.image_id
  name  = "db_msc_identity"
  ports {
    internal = 5432
    external = 5433
  }
  env = [
    "POSTGRES_DB=db_msc_identity",
    "POSTGRES_USER=sa",
    "POSTGRES_PASSWORD=root"
  ]
}

resource "docker_container" "db_msc_members" {
  image = docker_image.postgres.image_id
  name  = "db_msc_members"
  ports {
    internal = 5432
    external = 5434
  }
  env = [
    "POSTGRES_DB=db_msc_members",
    "POSTGRES_USER=sa",
    "POSTGRES_PASSWORD=root"
  ]
}

resource "docker_container" "db_msc_bookings" {
  image = docker_image.postgres.image_id
  name  = "db_msc_bookings"
  ports {
    internal = 5432
    external = 5435
  }
  env = [
    "POSTGRES_DB=db_msc_bookings",
    "POSTGRES_USER=sa",
    "POSTGRES_PASSWORD=root"
  ]
}

resource "docker_container" "db_msc_highlights" {
  image = docker_image.postgres.image_id
  name  = "db_msc_highlights"
  ports {
    internal = 5432
    external = 5436
  }
  env = [
    "POSTGRES_DB=db_msc_highlights",
    "POSTGRES_USER=sa",
    "POSTGRES_PASSWORD=root"
  ]
}

resource "docker_container" "db_msc_notifications" {
  image = docker_image.postgres.image_id
  name  = "db_msc_notifications"
  ports {
    internal = 5432
    external = 5437
  }
  env = [
    "POSTGRES_DB=db_msc_notifications",
    "POSTGRES_USER=sa",
    "POSTGRES_PASSWORD=root"
  ]
}

resource "docker_container" "sc_messenger" {
  image = docker_image.rabbitmq.image_id
  name  = "sc_messenger"
  ports {
    internal = 5672
    external = 5672
  }
  ports {
    internal = 15672
    external = 15672
  }
}