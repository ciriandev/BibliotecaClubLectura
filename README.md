# BibliotecaClubLectura

## Estructura de la Base de Datos

Este proyecto utiliza una base de datos MySQL para gestionar una biblioteca. A continuación, se detalla la estructura de las tablas:

### Tabla: `libros`

Almacena información sobre los libros disponibles en la biblioteca.

| Campo           | Tipo de Datos      | Restricciones                      |
|------------------|--------------------|------------------------------------|
| `librosid`       | INT               | PRIMARY KEY, AUTO_INCREMENT        |
| `titulo`         | VARCHAR(255)      | NOT NULL                           |
| `autor`          | VARCHAR(255)      | NOT NULL                           |
| `isbn`           | VARCHAR(13)       | UNIQUE                             |
| `genero`         | VARCHAR(100)      | NULLABLE                           |
| `año_publicacion`| YEAR              | NULLABLE                           |
| `cantidad`       | INT               | DEFAULT 1, NOT NULL                |

---

### Tabla: `donaciones`

Registra las donaciones de libros realizadas por personas o entidades.

| Campo             | Tipo de Datos      | Restricciones                      |
|--------------------|--------------------|------------------------------------|
| `donacionesid`     | INT               | PRIMARY KEY, AUTO_INCREMENT        |
| `librosid`         | INT               | FOREIGN KEY REFERENCES `libros`    |
| `donante`          | VARCHAR(255)      | NOT NULL                           |
| `fecha_donacion`   | DATE              | NOT NULL                           |
| `cantidad_donada`  | INT               | NOT NULL                           |

---

### Tabla: `prestados`

Registra los libros prestados a los usuarios.

| Campo             | Tipo de Datos      | Restricciones                      |
|--------------------|--------------------|------------------------------------|
| `prestadosid`      | INT               | PRIMARY KEY, AUTO_INCREMENT        |
| `librosid`         | INT               | FOREIGN KEY REFERENCES `libros`    |
| `usuariosid`       | INT               | FOREIGN KEY REFERENCES `usuarios`  |
| `usuario`          | VARCHAR(255)      | NOT NULL                           |
| `fecha_prestamo`   | DATE              | NOT NULL                           |
| `fecha_devolucion` | DATE              | NULLABLE                           |
| `estado`           | ENUM              | DEFAULT 'prestado', NOT NULL (`prestado`, `devuelto`, `atrasado`) |

---

### Tabla: `usuarios`

Almacena información de los usuarios registrados en la biblioteca.

| Campo             | Tipo de Datos      | Restricciones                      |
|--------------------|--------------------|------------------------------------|
| `usuariosid`       | INT               | PRIMARY KEY, AUTO_INCREMENT        |
| `nombre`           | VARCHAR(255)      | NOT NULL                           |
| `apellido`         | VARCHAR(255)      | NOT NULL                           |
| `email`            | VARCHAR(255)      | UNIQUE, NOT NULL                   |
| `telefono`         | VARCHAR(15)       | UNIQUE, NULLABLE                   |
| `direccion`        | TEXT              | NULLABLE                           |
| `fecha_registro`   | DATE              | DEFAULT CURRENT_DATE               |

---

### Relaciones entre Tablas

- `libros` tiene una relación **uno-a-muchos** con `donaciones`.
- `libros` tiene una relación **uno-a-muchos** con `prestados`.
- `usuarios` tiene una relación **uno-a-muchos** con `prestados`.
