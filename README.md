# 🧸 SIN STOCK

**SIN STOCK** es un videojuego runner 3D desarrollado en Unity por el equipo **DreamScape**.

**Fulbito**, un osito animado, necesita recuperar los alfajores legendarios dispersos por todo el territorio. Mientras recorre diferentes pistas dinámicas de tres carriles, va recolectando alfajores comunes, esquivando obstáculos del entorno y derribando barreras.

Cada alfajor especial consumido le otorgará una forma única que desbloquea nuevas habilidades de juego.

**Diversificador utilizado:** Cultura Nacional – Comida Argentina.

## 🎮 Mecánicas

- **Movimiento:** Fulbito avanza automáticamente y puede desplazarse entre tres carriles para esquivar obstáculos y recolectar ítems.
- **Salto:** Permite superar determinados obstáculos durante el recorrido.
- **Alfajores especiales:** Al consumir alfajores legendarios, Fulbito cambia de forma y desbloquea habilidades temporales.
- **Transformaciones:** El personaje puede adoptar diferentes formas, como el Golem de Chocolate y el Osito Rosado.
- **Obstáculos:** El jugador debe evitar obstáculos o derribar barreras utilizando las habilidades correspondientes.
- **Recolección:** El objetivo es recuperar alfajores mientras se avanza por el recorrido.

## 🖥️ Plataformas

El videojuego cuenta con dos versiones:

- **PC (Windows):** versión original desarrollada para controles mediante teclado.
- **Android:** adaptación para dispositivos móviles con controles táctiles mediante gestos.

La adaptación busca conservar la experiencia original del runner, modificando los sistemas de interacción y la interfaz para aprovechar las características de los teléfonos móviles.

## 🕹️ Controles

### PC

| Tecla | Acción |
|---|---|
| A / ← | Cambiar al carril izquierdo |
| D / → | Cambiar al carril derecho |
| Espacio | Saltar |

El personaje avanza automáticamente.

### Android

| Gesto | Acción |
|---|---|
| Deslizar hacia la izquierda | Cambiar al carril izquierdo |
| Deslizar hacia la derecha | Cambiar al carril derecho |
| Deslizar hacia arriba | Saltar |

Los controles móviles utilizan gestos táctiles sin necesidad de botones de movimiento visibles, permitiendo mantener despejada la visualización del recorrido.

## 📱 Adaptación a Android

Como parte del trabajo final de la materia **Diseño según Plataforma de Juego**, se realizó el porteo de SIN STOCK desde PC hacia dispositivos Android.

### Cambios implementados

**1. Sistema de controles táctiles**

Se incorporó un sistema de reconocimiento de gestos para reemplazar los controles de teclado. El jugador puede cambiar de carril y saltar deslizando el dedo sobre la pantalla.

**2. Tutorial interactivo**

Se desarrolló un tutorial que explica los controles mediante instrucciones visuales y animaciones de una mano.

El jugador debe realizar correctamente los siguientes movimientos:

- Deslizar hacia la izquierda.
- Deslizar hacia la derecha.
- Deslizar hacia arriba para saltar.

El tutorial se presenta automáticamente la primera vez y su finalización se registra mediante PlayerPrefs.

**3. Práctica de controles**

Se incorporó la opción **Cómo jugar → Practicar controles** desde el menú principal.

Esta funcionalidad permite repetir el tutorial sin iniciar directamente una partida.

Al finalizar la práctica, el jugador puede elegir entre:

- **Jugar ahora:** comenzar la partida.
- **Volver al menú:** regresar a la pantalla principal.

**4. Adaptación de la interfaz**

Se realizaron ajustes en los elementos de la interfaz para facilitar su utilización en dispositivos móviles, manteniendo la orientación horizontal (landscape).

**5. Sincronización del inicio de partida**

Se ajustó el sistema de cámara y la generación de obstáculos para evitar que aparezcan demasiado cerca del jugador durante la presentación inicial.

Los controles permanecen bloqueados durante la transición de cámara y la generación de obstáculos comienza después de un tiempo de preparación.

**6. Pruebas en dispositivos reales**

Se generó una versión APK y se realizaron pruebas en teléfonos Android para verificar el funcionamiento de los controles, la interfaz y las mecánicas principales.

## 📊 Comparación entre plataformas

| Característica | PC | Android |
|---|---|---|
| Movimiento | Teclado A/D o flechas | Gestos izquierda/derecha |
| Salto | Barra espaciadora | Deslizamiento hacia arriba |
| Interacción | Teclado | Pantalla táctil |
| Orientación | Horizontal | Horizontal |
| Tutorial | Controles de teclado | Tutorial interactivo de gestos |
| Interfaz | Diseñada para PC | Adaptada a dispositivos móviles |
| Distribución | Ejecutable de Windows | Archivo APK |

## ⚙️ Requisitos técnicos

### Desarrollo

- **Motor:** Unity 6.3 (6000.3.11f1).
- **Lenguaje de programación:** C#.
- **Plataforma original:** PC (Windows).
- **Plataforma de destino:** Android.
- **Orientación móvil:** horizontal (landscape).

### Requisitos de Android

- **Versión mínima configurada:** Android 7.1 Nougat (API Level 25).
- **Controles:** pantalla táctil mediante gestos de deslizamiento.
- **Orientación:** horizontal.

### Dispositivos utilizados para las pruebas

- Samsung Galaxy A56.
- Samsung Galaxy A21s.

La versión Android fue probada en ambos dispositivos para comprobar el funcionamiento de las mecánicas, los controles táctiles y la navegación entre interfaces.

La versión mínima de Android indicada corresponde a la configuración del proyecto en Unity; las pruebas prácticas se realizaron en los dispositivos mencionados.

## 📥 Descarga del videojuego

Las versiones ejecutables de PC y Android se encuentran disponibles en Google Drive.

### [📂 Descargar SIN STOCK – PC y Android](https://drive.google.com/drive/folders/1ItgGBNfuev2XC4FE7Pkn4K9XbWT77Ks7?usp=sharing)

La carpeta contiene las compilaciones destinadas a la evaluación del proyecto.

## 🚀 Instalación y ejecución

### Versión PC (Windows)

1. Acceder al enlace de Google Drive.
2. Descargar la compilación para PC.
3. Descomprimir el archivo si se encuentra comprimido.
4. Ejecutar el archivo `.exe` del videojuego.
5. Utilizar A/D o las flechas para desplazarse entre carriles y Espacio para saltar.

### Versión Android

1. Acceder a la carpeta de Google Drive desde un dispositivo Android.
2. Descargar el archivo `.apk`.
3. Autorizar la instalación desde esa fuente si el sistema lo solicita.
4. Instalar la aplicación.
5. Abrir SIN STOCK.
6. Utilizar gestos táctiles para controlar a Fulbito.

### Ejecución desde Unity

Para abrir el proyecto desde el editor:

1. Clonar o descargar el repositorio.
2. Seleccionar la rama correspondiente a la plataforma.
3. Abrir el proyecto mediante Unity Hub.
4. Utilizar Unity 6.3 (6000.3.11f1).
5. Abrir la escena principal del proyecto.
6. Ejecutar el juego desde el editor o generar la compilación correspondiente.

## 🌿 Organización del repositorio

El proyecto está organizado en dos ramas principales para diferenciar la versión original de su adaptación.

| Rama | Descripción |
|---|---|
| `main` | Versión base de SIN STOCK para PC |
| `VersionMobile` | Versión adaptada para dispositivos Android |

**Repositorio GitHub:**

https://github.com/salvavelazquez/SinStock-Mejorado

**Rama de adaptación Android:**

https://github.com/salvavelazquez/SinStock-Mejorado/tree/VersionMobile

## 🛠️ Herramientas y tecnologías

- **Motor de desarrollo:** Unity.
- **Lenguaje de programación:** C#.
- **Control de versiones:** Git y GitHub.
- **Modelado y arte 3D:** Blender.
- **Diseño sonoro:** Reaper.
- **Diseño de interfaz:** Adobe Illustrator y Adobe Photoshop.

## 👥 DreamScape Team

### Benencia Álvaro

**3D Artist**


### Velázquez Augusto

**Programmer, Game Designer, Game Developer**


### Condorí Pérez Maximiliano Ezequiel

**Programmer, Game Designer, Game Developer**

### González Yanina Yasmín

**Sound Designer, Composer, UI Designer**

## 🎓 Contexto académico

Este proyecto fue desarrollado en el marco de la materia **Diseño según Plataforma de Juego**, de la Facultad de Ingeniería de la Universidad Nacional de Jujuy (UNJu).

La adaptación a Android forma parte del trabajo final, cuyo objetivo es analizar, implementar y justificar el porteo de un videojuego desde su plataforma original hacia otra plataforma, considerando las características técnicas y la experiencia del jugador.

## 📄 Disclaimer

Este videojuego ha sido desarrollado exclusivamente con fines recreativos, artísticos y educativos en el marco de una materia de la Facultad de Ingeniería de la Universidad Nacional de Jujuy.

El uso de la identidad visual de **Fulbito** es de carácter ilustrativo para un proyecto académico sin fines de lucro y no implica ninguna relación oficial con los propietarios de la marca.

Los derechos de las marcas y recursos de terceros pertenecen a sus respectivos titulares.
