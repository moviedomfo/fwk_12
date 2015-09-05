Para la ejecucion de todos los proyectos q levantan algun servicio WCF hay que iniciar el VS como administrador

WcfDispatcher_Host :
Es un proyecto de consola que levanta un FwkService:

<add baseAddress="net.tcp://localhost:8001/FwkService"/> --> Service point 
<add baseAddress="http://localhost:8732/WcfDispatcher/FwkService/"/> --> Metadata Exchange point


WcfDispatcherSvc
Es un proyecto windows service que levanta un FwkService: