'''cs

Verbose, Debug, Infomation, Warning, Error, Fatal
        
// string
Log.Information("Initialize {0}", this);

// message templates 
// this is for a object
Log.Debug("Create a MainWindow {@MainWindow} at {now}", this, DateTime.Now);

// the type of a object
Log.Debug("Type: {$Data}", myobject)

// we have a try catch in the Main Method        
Log.Error(ex, "Failed in {0}", ex.Message);
throw new NotImplementedException("Oops! MainWindow is not implement!");

'''