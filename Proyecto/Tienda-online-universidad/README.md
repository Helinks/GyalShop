# Tienda Online - Java (NetBeans + MySQL)

Proyecto académico desarrollado en Java puro (JFrame) con autenticación de usuarios y conexión a base de datos MySQL

---

# Tecnologías usadas: 

* Java (JDK 8+)
* NetBeans
* MySQL
* JDBC
* BCrypt (hash de contraseñas)

---

# Importante sobre dependencias (.jar)

Las librerías necesarias ya están incluidas en el proyecto dentro de la carpeta:

```
src/lib/
```

### Librerías incluidas:

* `mysql-connector-j-8.x.x.jar` → conexión a MySQL
* `jbcrypt-0.4.jar` → encriptación de contraseñas

👉 **NO necesitas volver a descargarlas**
👉 Solo debes asegurarte de que estén agregadas en el proyecto en NetBeans:

### Cómo agregarlas (si no aparecen):

1. Click derecho en el proyecto
2. Properties
3. Libraries
4. Add JAR/Folder
5. Seleccionar los `.jar` desde `src/lib`

---

#  Estructura del proyecto

```
src/
│
├── config/            → conexión a base de datos
├── controller/        → lógica intermedia (AuthController)
├── service/           → lógica de negocio (UsuarioService)
├── Model/             → entidades (Usuario)
├── enums/             → roles del sistema
├── View/              → interfaces gráficas (JFrame)
│   ├── Login
│   ├── SignUp
│   ├── Dashboard
│   └── Home
│
├── images/            → recursos gráficos
└── lib/               → dependencias (.jar)
```

---

# Configuración

Editar credenciales en:

```
config/ConexionBD.java
```

```java
private static final String URL = "jdbc:mysql://localhost:3306/tienda";
private static final String USER = "root";
private static final String PASSWORD = "";
```

---

# Guía para desarrolladores

## 🔹 1. Clonar el proyecto

```bash
git clone <URL_DEL_REPO>
cd Tienda_Online
```

---

## 🔹 2. Si la rama YA existe en GitHub pero NO en tu local

```bash
git fetch

git checkout -b nombreRama origin/nombreRama
```

Ejemplo:

```bash
git checkout -b dilanDev origin/dilanDev
```

---

## 🔹 3. Ver ramas disponibles

```bash
git branch
```

```bash
git branch -r   # ramas remotas
```

---

## 🔹 4. Trabajar en tu rama

```bash
git checkout dilanDev

git add .
git commit -m "feat: cambios"
git push
```

---

## 🔹 5. Traer cambios de main a tu rama

```bash
git checkout dilanDev
git merge main
```

---

## 🔹 6. Subir cambios a producción (main)

```bash
git checkout main
git merge dilanDev
git push
```

---

💻 Desarrollado por Dilan Gutierrez, Kevin, Sofia, Katterin

