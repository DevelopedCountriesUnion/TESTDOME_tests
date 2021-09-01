              // Difficulty: Easy   
              //Duration: 10min
//Refactor the AlertService and MapAlertDAO classes:
//1. Create a new package-private interface, named AlertDAO, that contains the same methods as MapAlertDAO.
//2. MapAlertDAO should implement the AlertDAO interface.
//3. AlertService should have a constructor that accepts AlertDAO.
//4. The raiseAlert and getAlertTime methods should use the object passed through the constructor.

================================================
  
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

class AlertService 
{
    //private final MapAlertDAO storage = new MapAlertDAO();
    private final AlertDAO storage;
    
    public AlertService (AlertDAO alert)
    {
        storage = alert;
    }
    
    
    public UUID raiseAlert() {
        return this.storage.addAlert(new Date());
    }
	
    public Date getAlertTime(UUID id) {
        return this.storage.getAlert(id);
    }	
}

class MapAlertDAO implements AlertDAO 
{
    private final Map<UUID, Date> alerts = new HashMap<UUID, Date>();
	
    public UUID addAlert(Date time) {
    	UUID id = UUID.randomUUID();
        this.alerts.put(id, time);
        return id;
    }
	
    public Date getAlert(UUID id) {
        return this.alerts.get(id);
    }	
}

interface AlertDAO 
{
     UUID addAlert(Date time);
     Date getAlert(UUID id);
}

