# Usa la imagen oficial de PostgreSQL
FROM postgres:latest

# Copia el archivo de configuración personalizado al contenedor
COPY ./postgresql.conf /etc/postgresql/postgresql.conf

# Toma el puerto para el contenedor
EXPOSE 9876

# Configura PostgreSQL para usar el archivo de configuración personalizado
CMD ["postgres", "-c", "config_file=/etc/postgresql/postgresql.conf"]

# Muestra mi nombre en el log al crear el contenedor
# CMD ["echo", "¡Soy Alexis y este es mi contenedor!"]
