<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# El patrón Observer

## Contexto

Código de ejemplo del patrón [Observer](https://en.wikipedia.org/wiki/Observer_pattern). Está basado en el código provisto
en el ejemplo del patrón [Observer en C#](https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern) aunque intencionalmente no
utiliza las interfaces [IObservable](https://learn.microsoft.com/en-us/dotnet/api/system.iobservable-1?view=net-7.0) ni [IObserver](https://learn.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-7.0).

El patrón Observer es un patrón en el que un objeto, llamado 
**sujeto** —*subject*—, mantiene una  lista de sus dependientes, llamados 
**observadores** —*observers*—, y les notifica automáticamente cualquier 
cambio de estado, generalmente llamando a uno de sus métodos.

## Código provisto

El ejemplo consiste esencialmente de tres clases:

* Temperature
* TemperatureSensor
* TemperatureReporter

En este ejemplo la idea es que el `TemperatureReporter` muestre valores de 
`Temperature` a medida que el `TemperatureSensor` detecta que van cambiando.

### Temperature

Representa una lectura de un sensor de temperatura

| Responsabilidades | Colaboraciones |
|-------------------|----------------|
| Conocer una lectura de temperatura ||
| Conocer la fecha y hora en que se leyó la temperatura ||

### TemperatureSensor

Representa un sensor de temperatura

| Responsabilidades | Colaboraciones |
|-------------------|----------------|
| Conocer la temperatura actual | Temperature |
| Conocer los reportadores interesados en la temperatura actual | TemperatureReporter |
| Agregar un reportador interesado ||
| Remover un reportador previamente agregado ||

### TemperatureReporter

Representa un dispositivo capaz de mostrar valores —por ejemplo un display 
de siete segmentos o un monitor—

| Responsabilidades | Colaboraciones |
|-------------------|----------------|
| Conectarse a un monitor de temperatura | TemperatureSensor |
| Desconectarse de un monitor de tempratura ||
| Recibir actualizaciones del monitor de temperatura ||

## Diagramas

A continuación mostramos esas clases en un diagrama:

![Diagrama de clases](./images/Observer-Clases.svg?sanitize=true)

Este es un diagrama de los mensajes intercambiados entre las clases:

![Diagrama de interacciones](./images/Observer-Interaciones.svg?sanitize=true)

## Desafio

Modifiquen las clases provistas para que exista un tipo `ISubject` y otro
`IObserver` con las responsabilidades  de hacer que se muestran a 
continuación. El objetivo es que `TemperatureSensor` no conozca a
`TemperatureReporter` sino que pueda reportar los cambios de temperatura a 
cualquier objeto interesado mientras sea de tipo `IObserver`.

A la vez `TemperatureReporter` no tiene por qué conocer a `TemperatureSensor`
sino que puede reportar los cambios de temperatura de cualquier objeto 
`ISubject` que pueda notificárselos.

Una vez que implementen estos cambios verán el polimorfismo y el principio 
de sustitución de Liskov en acción. Cualquier objeto que tenga el tipo 
`IObserver` podrá recibir notificaciones de un objeto de tipo `ISubject`, no 
importa de qué clase sea.

### ISubject

Representa un objeto observable `ISubject` que notifica sus cambios a objetos
observadores `IObserver`; este objeto no conoce a priori a los observadores a
notificar sino que éstos se suscriben a demanda.

| Responsabilidades | Colaboraciones |
|-------------------|----------------|
| Conocer los observadores interesados en cambios de este objeto | IObserver |
| Agregar un observador ||
| Remover un observador previamente agregado ||
| Notificar cambios en este objeto a los observadores ||

### IObserver

Representa un objeto observador `IObserver` que desea conocer cambios en otro
objeto observado `ISubject`.

| Responsabilidades | Colaboraciones |
|-------------------|----------------|
| Recibir actualizaciones cuando haya cambios en el objeto observado | ISubject |

> [!IMPORTANT]
> El programa funciona, pero existe una dependencia entre 
> `TemperatureSensor` y `TemperatureReporter` porque se conocen mutuamente, el
> desafío es introducir las interfaces `IObserver` e `ISubject` para 
> eliminar esa dependencia.

> [!WARNING]
> Los casos de prueba **no** pasan. Pasarán una vez que introduzcan 
> correctamente las interfaces `IObserver` e `ISubject` y modifiquen
> apropiadamente las clases `TemperatureSensor` y `TemperatureReporter`.
