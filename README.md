[![Evoltis](https://evoltis.com/wp-content/uploads/2022/06/0-logo-evoltis-color-300x80.png "Evoltis")](https://evoltis.com/wp-content/uploads/2022/06/0-logo-evoltis-color-300x80.png "Evoltis")
# Proyecto de Gestión de Empleados

<p>Este proyecto consiste en una aplicación web desarrollada utilizando ASP.NET Web Forms (NET Framework) para implementar las operaciones CRUD (Create, Read, Update, Delete) en una entidad llamada "Empleados". La aplicación permite gestionar la información de los empleados, incluyendo sus atributos como ID, Nombre, Apellido, Correo Electrónico y Salario.</p>

### Instalación
- Clona este repositorio en tu máquina local.
- Abre el proyecto en Visual Studio.
- Configura la conexión a la base de datos en el archivo de configuración **Web.config** con el atributo **connectionStrings**
- Ejecuta la aplicación desde Visual Studio.

### Tecnologías Utilizadas
- ASP.NET Web Forms
- .NET Framework
- SQL Server Express
- Bootstrap (Framework de CSS)

### Descripción de la Aplicacion Web
<p>Página Principal de Gestión de Empleados: La página principal ** Index.aspx ** muestra una lista completa de todos los empleados existentes. Aquí se puede agregar, editar y eliminar empleados. Se han utilizado controles de ASP.NET Web Forms para diseñar la interfaz en el archivo ** Index.aspx.cs **:</p>

```csharp
protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        void cargarTabla()
        {
            SqlCommand cdm = new SqlCommand("Cargar_Datos", conec);
            cdm.CommandType = CommandType.StoredProcedure;
            conec.Open();
            SqlDataAdapter da = new SqlDataAdapter(cdm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TbEmpleados.DataSource = dt;
            TbEmpleados.DataBind();
            conec.Close();
        }
```
</br>
<p>Creación, Edición y Eliminación de Empleados: Para agregar, editar o eliminar empleados, se utiliza una ventana creada en el archivo **Empleados.aspx**. Los usuarios pueden ingresar datos como nombre, apellido, correo electrónico y salario del empleado. Al guardar, los datos se almacenan o actualizan en una base de datos. Si el usuario desea borrar un empleado, este mismo se eliminara de la lista y de la base de datos. Se ha utilizado SQL Server Express como base de datos: </p>

``` sql
CREATE DATABASE Evoltis

USE Evoltis

CREATE TABLE Empleados(
Id_Empleado INT IDENTITY(1,1),
Nombre VARCHAR(100),
Apellido VARCHAR(100),
Correo VARCHAR(MAX),
Salario INT
)

CREATE PROCEDURE Cargar_Datos
AS BEGIN
SELECT * FROM Empleados
END

--CRUD: CREATE, READ, UPDATE, DELETE

CREATE PROCEDURE Crear
@Nombre VARCHAR(100),
@Apellido VARCHAR(100),
@Correo VARCHAR(MAX),
@Salario INT
AS BEGIN
INSERT INTO Empleados VALUES(@Nombre, @Apellido, @Correo, @Salario)
END

CREATE PROCEDURE Leer
@Id INT
AS BEGIN
SELECT * FROM Empleados WHERE Id_Empleado=@Id
END

CREATE PROCEDURE Editar
@Id INT,
@Nombre VARCHAR(100),
@Apellido VARCHAR(100),
@Correo VARCHAR(MAX),
@Salario INT
AS BEGIN
UPDATE Empleados SET Nombre=@Nombre, Apellido=@Apellido, Correo=@Correo, Salario=@Salario
WHERE Id_Empleado=@Id
END

CREATE PROCEDURE Borrar
@Id INT
AS BEGIN
DELETE FROM Empleados WHERE Id_Empleado=@Id
END

SELECT * FROM Empleados
```
</br>

<p> Búsqueda de Empleados por Nombre: La página de gestión permite buscar empleados por su nombre ingresando el nombre y presionando el botón "Buscar":</p>
``` asp
<div class="col-md-4 d-flex align-items-end justify-content-end text-right ">
                <asp:TextBox runat="server" ID="TxtSearch" CssClass="form-control" placeholder="Buscar por nombre"></asp:TextBox>
                <asp:Button runat="server" ID="BtnSearch" CssClass="btn btn-primary" Text="Buscar" OnClick="BtnSearch_Click" />
            </div>
```
<p> Al ingresar un nombre, se muestra en la lista de empleados cuyos nombres coincidan en la base de datos:</p>
``` csharp
protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string nombreBuscado = TxtSearch.Text.Trim();

            SqlCommand cmd = new SqlCommand("SELECT [Id_Empleado], [Nombre], [Apellido], [Correo], [Salario] FROM [Evoltis].[dbo].[Empleados] WHERE [Nombre] LIKE @Nombre", conec);
            cmd.Parameters.AddWithValue("@Nombre", "%" + nombreBuscado + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TbEmpleados.DataSource = dt;
            TbEmpleados.DataBind();
        }
```
</br>
<p> Validaciones de Datos: Se han implementado validaciones para asegurar que los campos requeridos se ingresen correctamente y que el correo electrónico tenga un formato válido.</p>
</br>
<p> Framework de CSS y JavaScript: Se ha utilizado el framework Bootstrap en la pagina maestra **Site.Master** para dar estilo a la aplicación web, mejorando su presentación y facilitando la interacción del usuario con las funcionalidades implementadas:</p
``` html
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
```



