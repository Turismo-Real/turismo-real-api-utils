# Turismo Real Utils  
Servicio REST con utilidades para el front.  

### Rutas  
- http://localhost:4999/api/v1/utils/pais
  - Obtiene los paises disponibles en la bsae de datos.  
- http://localhost:4999/api/v1/utils/region
  - Obtiene las regiones disponibles en la base de datos.  
- http://localhost:4999/api/v1/utils/comuna
  - Obtiene las comunas de una región que es recibida como payload de entrada.  

```
# EJEMPLO PAYLOAD PARA OBTENER COMUNAS POR REGIÓN
{
    "region": "Metropolitana de Santiago"
}
```  
Si region enviada en payload no corresponde a ninguna en la base de datos se espera como respuesta:  
```
[
    null,
    "No hay comunas para la región especificada."
]
```