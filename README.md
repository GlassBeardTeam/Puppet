# Pappets

## Documento de diseño
Versión 1.0

### Glass Beard

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Logo(200x200).png)
- Adrián Poza Guillermo - Artista 
- Víctor González Rivera - Diseñador, programador
- Álvaro Ramírez Míguez - Diseñador, programador, sonido
- Manuel Aguado Salguero - Artista
- Miguel Ángel Arcones Ríos - Programador 

### Índice
[Pitch](https://github.com/GlassBeardTeam/Puppet#pitch)
  * [Propósito y público objetivo](https://github.com/GlassBeardTeam/Puppet#prop%C3%B3sito-y-p%C3%BAblico-objetivo)
  * [Plataforma y monetización](https://github.com/GlassBeardTeam/Puppet#plataforma-y-monetizaci%C3%B3n)
  
[Mecánicas](https://github.com/GlassBeardTeam/Puppet#mec%C3%A1nicas)
  * [Controles](https://github.com/GlassBeardTeam/Puppet#controles)
  * [Puntuación](https://github.com/GlassBeardTeam/Puppet#puntuaci%C3%B3n)
  * [Personalización](https://github.com/GlassBeardTeam/Puppet/blob/master/README.md#personalizaci%C3%B3n)

[Interfaz](https://github.com/GlassBeardTeam/Puppet#interfaz)

[Arte](https://github.com/GlassBeardTeam/Puppet#arte)
  * [Historia](https://github.com/GlassBeardTeam/Puppet#historia)
  * [Estética](https://github.com/GlassBeardTeam/Puppet#est%C3%A9tica)
  * [Música y Sonido](https://github.com/GlassBeardTeam/Puppet#m%C3%BAsica-y-sonido)
  
[Redes Sociales](https://github.com/GlassBeardTeam/Puppet#redes-sociales)

## Pitch
__Pappet__ es un juego de plataformas 2D en el que manejas a una marioneta, accionando sus articulaciones para desplazarte y golpear a enemigos. 
### Propósito y público objetivo
El propósito es crear un juego de plataformas con mecánicas innovadoras en el que puedas personalizar a tu personaje, orientado a jugadores habituales del género que busquen nuevas formas de jugar. 
### Plataforma y monetización
El juego estará adaptado para cualquier dispositivo con navegador Chrome o Firefox (Pc, móvil, tablet...) y Facebook.

Se distribuirá de forma gratuita en plataformas digitales, como Steam, Itch.io o Humble Bundle ya que la principal fuente de ingresos será la venta de pegatinas para personalizar a tu personaje (ver "Personalización" para más información).

## Mecánicas
La mecánica principal del juego consiste en contraer y relajar las articulaciones de la marioneta para rotar al personaje e impulsarte en la dirección deseada. Además, se podrá  interactuar con el escenario (saltando contra las paredes, empleando muelles para saltar más alto o derrotar a enemigos con tus extremidades).

El objetivo principal es alcanzar la meta en el menor tiempo posible, recogiendo objetos (engranajes, bobinas...) y superando los obstáculos que se interpongan en tu camino. A lo largo del nivel habrá puntos de control, que consisten en soportes de marionetas que se activan golpeándolos con tus extremidades.

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Bocetos%20Marionetas2.png)

__Engranajes:__ Deberás recoger un número determinado para desbloquear la meta.

__Bobinas:__ Servirán como moneda en el juego, habrá un número limitado en cada nivel y permitirán cambiar la apariencia del personaje. Por lo general serán más difíciles de conseguir que los engranajes ya que no son necesarios para completar el nivel.

__Enemigos:__ En caso de que toquen tu cabeza o tu tronco volverás al punto de control. Para derrotarlos, debes acertar un golpe con tus extremidades.

__Obstáculos:__ 
* plataformas móviles
* muelles
* balas de cañón: Te empujan en la dirección en la que se dirijan.
* sierras: hacen la marioneta pedazos al más mínimo contacto.

### Controles
La marioneta se controla con 3 botones:

* Botón 1: Al pulsarlo se contraen las piernas, de forma que la marioneta se agacha. Al soltarlo, la marioneta sale disparada en la dirección a la que apunte su cabeza. Barra espaciadora en PC y parte central de la pantalla en dispositivos táctiles.
* Botones 2 y 3: Sirven para contraer los brazos izquierdo y derecho respectivamente. Al contraer el brazo izquierdo, la marioneta rota su cuerpo hacia la derecha y viceversa. Teclas A y D en PC y zonas izquierda y derecha de la pantalla en dispositivos táctiles.

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Bocetos%20Marionetas3.png)

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/controlesAire.png)

Los botones podrían controlar otras articulaciones en caso de que se añadan nuevas marionetas, aunque las mecánicas básicas de rotar al personaje e impulsarse se mantendrían.

### Puntuación
La puntuación obtenida en un nivel dependerá del tiempo que tardes en completarlo y del porcentaje de coleccionables que consigas en el mismo.

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Scoreboard.JPG)

### Personalización: 
Los jugadores podrán personalizar a su marioneta escogiendo pegatinas específicas para cada parte del cuerpo (5 en total).
Las pegatinas se podrán conseguir de 3 formas:
* Gastando Bobinas para obtener una pegatina al azar que no poseeas previamente.
* Comprando un set de 10 pegatinas por 0,49€. Este set incluiría Cabeza, torso, brazos, antebrazos, piernas y pies de un mismo conjunto.
* Comprando el pack completo de pegatinas por 2,49€ que contendría 10 sets de pegatinas (100 pegatinas).
De esta forma, cualquiera puede obtener todas las pegatinas del juego de forma gratuita, pero tendría que dedicarle bastante tiempo al juego haciendo más probable que se quede y/o siga jugando.

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Personalizar.png)

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Vestuario.JPG)

## Interfaz
__Menú principal__
* Aventura
  * Selección de Nivel
    * Juego
* Vestuario: Personalización de la marioneta y tienda.
* Opciones: Volumen de sonidos, música, idioma.
  * Contacto

__Juego__
* Nivel
* Cronómetro
* Engranajes conseguidos
* Bobinas de hilo conseguidas

Imágenes: 
- Menú Principal:
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Menu.JPG)
- Selección de nivel:
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Niveles.JPG)
- Juego:
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Nivel_2.JPG)
- Vestuario:
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Vestuario.JPG)
- Opciones:
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Opciones.JPG)
## Arte
### Historia
Te despiertas en un teatro de títeres abandonado que es llevado en la actualidad por las propias marionetas, pappets, y no te queda más remedio que seguir las indicaciones del dueño, el Pappet Master Diantre, que te realizará una serie de pruebas para decidir si te contrata y entretengas al público, hasta que te vuelves demasiado fuerte como para que pueda controlarte y decide acabar contigo.

__Personajes__
- Títere: Personaje principal que controlará el jugador durante la historia. Es una marioneta tradicional desechada por su antiguo dueño.

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/puppet1.png)

- Diantre: Una caja de payaso que será tu maestro en el juego y te guiará durante el tutorial. Su método de enseñanza es un tanto peculiar. No parará de hacer bromas con la forma de desplazarse de Títere y dará más problemas que facilidades a tu avance.
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Bocetos%20Puppet%20Master.png)

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/diantre.png)

### Estética
Se ha elegido una estética cartoon, simulando recortes de cartón, con pegatinas desgastadas que se pueden ir intercambiando. Coge inspiración en los teatros de títeres para niños y niñas y en las manualidades que podrían hacer éstos y éstas en el colegio.

A su vez, se sigue una temática de circo o teatro de finales de siglo XIX, con posters coloridos y desgastados.

Bocetos:
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Bocetos%20Marionetas.png)

Pegatinas: 
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/P2Cabeza.png)

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/P3cabeza.png)

### Música y Sonido
La música debe ser animada y circense, de forma que recuerde a un teatro de marionetas.

Sonido: 
- Cartón golpeando al moverse el personaje.
- Hilos al contraer articulaciones.
- Golpear a un objetivo.
- Recibir daño.
- Diálogos de Diantre.
- Muelle y caja de Diantre.
- Coger bobina.
- Alcanzar la meta.
- Enemigos.
- Mecanismos y peligros del nivel.


## Redes Sociales
E-mail: GlassBeardTeam@gmail.com

Twitter: [@glass_beard](https://twitter.com/glass_beard)

Facebook: [Glass BeardTeam](https://www.facebook.com/glass.beardteam.7)

Portfolio: [Glass Beard Team](https://glassbeardteam.github.io/Portfolio/)

Itch.io: [Pappet](https://glassbeard.itch.io/)


© 2019 GitHub, Inc.


