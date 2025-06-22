# Documentación Backend del proyecto "Mini Core (Comisiones)"
![net](https://img.shields.io/badge/dotnet-purple?logo=dotnet&label=.NET%208.0)






### 🌀 Backend Mini Core 2025 🌀

> Este es backend de mi proyecto usando el ecosistema de .NET, el la cual es un WebApi (APIRest) donde esta implementado la logica del mini Core.
> La base de datos usada es el NoSQL **DynamoDB** de AWS, donde se almacena la imformación de los vendedores, ventas y las reglas. El patron aplicado
> es el de repositorio donde me ayuda a separar las responsabilidades de cada una de las clases y sobre todo para que pueda ser escalable a la hora de agregar nuevas funcionalidades.
> Por ultimo al realizar la implementación y las pruebas de la API, use el servicio de **AWS Lambda** para poder empaquetar y subirla a la nube, donde se puede consumir desde mi frontend.
> Al deployar mi API en AWS Lambda, use otro servicio de AWS que es el **API Gateway** donde me ayuda a facilitar las operaciones endpoints especificos desde un solo link y poder realizar
> el consumo efectivo de la API desde el FrontEnd (VueJs).

## Lista de elementos aplicados y aprendidos en este proyecto

| #  | Tema                   | Descripción                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            | Complejidad |
|----|------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------|
| 00 | **Patron Repositorio** | Este es uno de mis patrones favoritos al implementar mi backend en .NET porque gracias a ello me facilita la separación de responsabilidades, debido a la implementación de la interfaz. Con uno con varias interfaces es posible crear varios repositorio basados en las operaciones CRUD, y con ello facilita implementar el controlador.                                                                                                                                                                                            |![Static Badge](https://img.shields.io/badge/100-green?style=flat&label=Baja)
| 01 | **WebAPI**             | Una de las caracteristicas mas importantes de .NET es el WebApi donde como uusario es facil implementar APIRest tales como operaciones CRUD, autenticacion, JWT, Autorizacion, GraphQL entre otros. Es decir posee una versatilidad al momento de implementar el Backend.                                                                                                                                                                                                                                                              |![Static Badge](https://img.shields.io/badge/100-green?style=flat&label=Baja)
| 02 | **MVC**                | **MVC** es considerado el patron mas antiguo lo cual en su tiempo era el mas efectivo al momento de desarrollar una aplicación. Este patron cosiste en la separacion de resposabilidades, el modelo, la vista y el controlador. Existen varias maneras de implementar el patron MVC, en mi caso aplique el MC para el backend y el V para la vista que es el FrontEnd y lo unifique en un solo proyecto. Este patron sirve mucho para nivel educativo pero para proyectos mas grandes se hae el uso de patrones modernos como el MVVM. |![Static Badge](https://img.shields.io/badge/90-green?style=flat&label=Baja)
| 03 | **AWS Lambda**         | Al haber aprendido este servicio y sus funciones, realice la implementación y empaquetación del API usando uno de los servicios mas demandados de AWS, antes de empaquetar mi API, realice ciertas modificaciones desde .NET para poder enviar hacia la nube. Tuve exito al migrar hacia la nube de AWS ya que me resulto mas facil ejecutar desde mi FrontEnd.                                                                                                                                                                        |![Static Badge](https://img.shields.io/badge/60-yellow?style=flat&label=Medio)
| 04 | **AWS DynamoDB**       | Al implementar en Lambda mi backend yo use una base de datos diferente en este caso DynamoDB ya que es parte de AWS y me ayudaba de la forma mas facil a almacenar datos y no desde terceros como MongoDB. Ahora mi Backend esta con el sistema completo ligado a los servicios de AWS lo cual me da ciertas ventajas a la hora de consumir mi APIRest                                                                                                                                                                                 |![Static Badge](https://img.shields.io/badge/100-green?style=flat&label=Baja)

## Tecnologías usadas

![Static Badge](https://img.shields.io/badge/.NET%208.0-%23512BD4?style=for-the-badge&logo=dotnet&label=TOOL&labelColor=black) ![Static Badge](https://img.shields.io/badge/CSharp-%23512BD4?style=for-the-badge&logo=dotnet&label=LANGUAGE&labelColor=black)





## Instrucciones

**Si desea revisar el proyecto, puede clonar con git clone o descargar Zip.**

**Para usuarios de Visual Studio o Rider**

1. Una vez clonado o descargado el proyecto, solamente debera abrir la solución con el IDE de su preferencia, en este caso Visual Studio o Rider.

**Para usuarios de Visual Studio Code**

1. Una vez clonado o descargado el proyecto, debera abrir la carpeta del proyecto en Visual Studio Code. Para la ejecucion debe tener instalado el SDK de .NET 8.0 y el plugin de C#.

**Nota adicional de AWS**

Para poder ejecutar el proyecto desde su IDE, debera tener instalado el plugin de AWS Toolkit para su IDE, y
tener configurado su cuenta de AWS. Para la base de datos DynamoDB, debera crear una tabla con el nombre "RulerCore", "VendedorCore", "VentaCore" y
los atributos "Id". Para la API Gateway, debera crear un endpoint con el nombre "Comision.API" y asociarlo a la Lambda creada.

---

## <img src="https://github.com/AngelDavidStudios/calculadora-propinas/blob/main/src/resources/ads-emote.JPG" width="55" height="55"> Hola, mi nombre es David Angel.
### Multimedia Desginer & Software Architect

Soy diseñador Multimedia cursando una segunda carrera en Ingeniería de Software, me estoy especializando en el desarrollo Backend como arquitecto de software, en este recorrido dia tras dia aprendo tecnologias nuevas.

David Angel Studios es mi marca personal donde mi misión es desarrollar diversos proyectos basado en mi apredizaje de nuevas tecnologias y almacenarlas en mi portafolio personal:

[![Linkedin](https://img.shields.io/badge/Linkedin-4479A1?style=for-the-badge&logo=9gag&label=Angel%20David%20Studios&labelColor=black)](https://www.linkedin.com/in/angeldavidstudios/)
[![Instagram](https://img.shields.io/badge/Instagram-FF0069?style=for-the-badge&logo=instagram&label=Angel%20David%20Studios&labelColor=black)](https://www.instagram.com/angeldavidstudios/) [![Youtube](https://img.shields.io/badge/Angel--David--Studios-FF0000?style=for-the-badge&logo=youtube&label=Youtube.com%2F&labelColor=black)](https://www.youtube.com/channel/UC2VYRq169QluoLeagCYrjVg)