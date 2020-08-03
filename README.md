# NetCore
Project NetCore

- Proyecto 1.

- Proyecto 2.

- Proyecto 3. NetCore | SignalR | SQL | NCapas

	1 Creamos un proyecto nuevo.
		Instalado > Otros tipos de proyectos > soluciones de visual studio

	2 Creamos las carpetas de 1 PRESENTACION, 2 DOMINIO y 3 INFRAESTRUCTURA.

		2.1 En 1 PRESENTACION creamos otro proyecto.
			Instalado > Visual C# > .NET Core > Aplicación web ASP.NET CORE (VACIO). De nombre  "DemoNetCore21.Presentacion"
		2.2 Creamos las siguientes carpetas.
			CONTROLLERS
			MODELS
			VIEWS
		2.3 En la carpeta CONTROLLERS agregaremos un controlador.
			Agregar > CONTROLADOR > CONTROLADOR DE MVC: en blanco. Con nombre "HomeController"
			Agregamos su VISTA sin págin de diseño(desmarcamos el CHECK).

		2.4 Configuramos "STARTUP" que se encuentra PRESENTACION > DemoNetCore21.Presentacion.
			
		2.5 Estacemos como proyecto inicial.

		2.6 En wwwroot agregamos el SignalR, Jquery, Twitter-Boostrap.

			SIGNALR:
				@microsoft/signalr@latest
				wwwroot > agregar > agregar biblioteca de lado del cliente.
				Seleccionamos:
					Proveedor: unpkg
					Bibloteca: @aspnet/signalr@1.0.3
				Elejimos:
					Archivos > dist > browser > signalr.min.js

			JQUERY
				Seleccinamos:
				Proveedor: cdnjs
				Biblioteca: jquery@3.3.1

			Twitter-Boostrap
				Seleccionamos:
				Proveedor: cdnjs
				Biblioteca: twitter-boostrap@4.1.3
				** Sus estilos CSS

		2.7 En Home/Index.cshtml agregamos la tabla y js

		2.8 En STARTUP.cs agregamos el contructor "startup" y demas.

		2.9 Creamos el archivo.
			DemoNetCore21.Presentacion > agregar > nuevo elemento > ASP.NETCore > Archivo de configuracion de la aplicacion ASP.NETCore. Con nombre appsettings.json

		2.10 Activamos SIGNAL R en startup.cs


	3 En 2 DOMINIO creamos otro proyecto NET CORE > BIBLIOTECA DE CLASES (.NET CORE). De nombre "DemoNetCore21.Dominio"

	4 Dentro del proyecto creado en 2 DOMINIO creamos las carpetas.
		CONTRATOS.
			REPOSITORIOS.
			SERVICIOS.
		ENTIDADES.
		SERVICIOS. Servicios orientado a clases (Domain Drive Design).

		4.1 Crear en ENTIDADES la clase Producto.
		4.2 Crear en CONTRATOS/REPOSITORIOS el interfaz IRepositorioBase
			REPOSITORIOS > Agregar > Nuevo elemento > INTERFAZ. Con nombre IRepositorioBase
		4.3 Crear en CONTRATOS/REPOSITORIOS el interfaz IProductoRepositorio
			REPOSITORIOS > Agregar > Nuevo elemento > INTERFAZ. Con nombre IProductoRepositorio
		4.4 Crear en CONTRATOS/SERVICIOS el interfaz IProductoServicio
			SERVICIOS > Agregar > Nuevo elemento > INTERFAZ. Con nombre IProductoServicio
		4.5 Crear en SERVICIOS la clase ProductoServicio
			SERVICIOS > Agregar > clase. Con nombre ProductoServicio

	5 En 3 INFRAESTRUCTURA creamos otro proyecto NET CORE > BIBLIOTECA DE CLASES (.NET CORE). De nombre "DemoNetCore21.Infraestructura"

	6 Dentro del proyecto creado en 2 DOMINIO creamos las carpetas.
		REPOSITORIOS

	7 En 3 INFRAESTRUCTURA creamos otro proyecto NET CORE > BIBLIOTECA DE CLASES (.NET CORE). De nombre "DemoNetCore21.Infraestructura.Hubs"

	8 Dentro del proyecto creado "DemoNetCore21.Infraestructura.Hubs" creamos las carpetas.
		HUBS

		Fuente: https://www.youtube.com/watch?v=N4vv14nfp8M