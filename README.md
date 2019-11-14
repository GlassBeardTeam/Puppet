# Puppet Theater

## Documento de diseño
Versión 0.1

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
  * [Puntuación](https://github.com/GlassBeardTeam/Puppet#puntuaci%C3%B3n)
  * [Controles](https://github.com/GlassBeardTeam/Puppet#controles)
  
[Interfaz](https://github.com/GlassBeardTeam/Puppet#interfaz)

[Arte](https://github.com/GlassBeardTeam/Puppet#arte)
  * [Historia](https://github.com/GlassBeardTeam/Puppet#historia)
  * [Estética](https://github.com/GlassBeardTeam/Puppet#est%C3%A9tica)
  * [Música y Sonido](https://github.com/GlassBeardTeam/Puppet#m%C3%BAsica-y-sonido)
  
[Redes Sociales](https://github.com/GlassBeardTeam/Puppet#redes-sociales)

## Pitch
__Puppet Theater__ es un juego de plataformas 2D en el que manejas a una marioneta, accionando sus articulaciones para desplazarte y golpear a enemigos. 
### Propósito y público objetivo
El propósito es crear un juego de plataformas con mecánicas innovadoras, orientado a jugadores habituales del género que busquen nuevas formas de jugar.
### Plataforma y monetización
El juego estará adaptado para cualquier dispositivo con navegador Chrome o Firefox (Pc, móvil, tablet...) y Facebook.

Se distribuirá una versión inicial en plataformas digitales, como Steam, Itch.io o Humble Bundle, y se irá actualizando con cosméticos cada cierto tiempo.
Posteriormente se tratará de llevar a cabo una campaña de micromecenazgo para ampliar el videojuego con nuevas funcionalidades, como el modo multijugador.
Dicha campaña irá evolucionando en varias fases:

Fase 1: Micromecenazgo durante el desarrollo. Se  realizará una campaña de crowdfunding con diferentes niveles de apoyo y sus respectivas recompensas, como poder acceder a la versión alpha del videojuego o aparecer en los créditos del juego.

Fase 2: Lanzamiento de la versión alpha para los que hayan apoyado el juego.

Fase 3: Venta del juego completo en diferentes plataformas digitales de distribución de videojuegos. (Modo plataformas + multijugador)

Fase 4: Lanzamiento de acceso a multijugador de forma gratuita y Venta de cosméticos adicionales.
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

Los botones podrían controlar otras articulaciones en caso de que se añadan nuevas marionetas, aunque las mecánicas básicas de rotar al personaje e impulsarte se mantendrían.

### Puntuación
La puntuación obtenida en un nivel dependerá del tiempo que tardes en completarlo y del porcentaje de coleccionables que consigas en el mismo.

## Interfaz


## Arte
### Historia
Ideas:
* Cada 100 años se celebra una competición entre marionetas en el Puppet Theater para decidir a la marioneta maestra. Una caja de payaso con mucho tiempo libre y muy poco interés en la competición decide entrenarte para que consigas la victoria.
* Te despiertas en un teatro de marionetas y no te queda más remedio que seguir las indicaciones del dueño, que te entrenará para que entretengas al público, hasta que te vuelves demasiado fuerte como para que pueda controlarte y decide acabar contigo.

__Personajes__
- Títere: Personaje principal que controlará el jugador durante la historia. Es una marioneta tradicional desechada por su antiguo dueño.

- Socavón: Una caja de payaso que será tu maestro en el juego y te guiará durante el tutorial. Su método de enseñanza es un tanto peculiar. No parará de hacer bromas con la forma de desplazarse de Títere y dará más problemas que facilidades a tu avance.
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Bocetos%20Puppet%20Master.png)


### Estética
Se ha elegido una estética cartoon, simulando recortes de cartón, con pegatinas desgastadas que se pueden ir intercambiando. Coge inspiración en los teatros de títeres para niños y niñas y en las manualidades que podrían hacer éstos y éstas en el colegio.

Bocetos:
![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/Bocetos%20Marionetas.png)

![Error al cargar la imagen](https://github.com/GlassBeardTeam/Puppet/blob/master/GDD%20Images/boceto5.4.JPG)


### Música y Sonido
La música debe ser animada y circense, de forma que recuerde a un teatro de marionetas.

Sonido: 
- Madera golpeando al moverse el personaje.
- Hilos al contraer articulaciones.
- Golpear a un objetivo.
- Recibir daño.
- Diálogos de Puppet Master.
- Muelle y caja de Puppet Master.
- Coger bobina.
- Alcanzar la meta.
- Enemigos.
- Mecanismos y peligros del nivel.


## Redes Sociales
E-mail: GlassBeardTeam@gmail.com

Twitter: [@glass_beard](https://twitter.com/glass_beard)

Facebook: [Glass BeardTeam](https://www.facebook.com/glass.beardteam.7)

Portfolio: [Glass Beard Team](https://glassbeardteam.github.io/Portfolio/)

Itch.io: [Puppet Theater](https://glassbeard.itch.io/)


© 2019 GitHub, Inc.


