using Ucu.Poo.Observer;

TemperatureSensor sensor = new TemperatureSensor();
TemperatureReporter reporter = new TemperatureReporter();
reporter.StartReporting(sensor);
sensor.StartMeasuring();