namespace AgentPublishGSA
{
    partial class AgentGSAService
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.fsWatcher = new System.IO.FileSystemWatcher();
            this.eLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eLog)).BeginInit();
            // 
            // fsWatcher
            // 
            this.fsWatcher.EnableRaisingEvents = true;
            this.fsWatcher.Path = "c:\\temp\\GSA\\pool";
            this.fsWatcher.Changed += new System.IO.FileSystemEventHandler(this.fsWatcher_Changed);
            this.fsWatcher.Created += new System.IO.FileSystemEventHandler(this.fsWatcher_Created);
            this.fsWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fsWatcher_Deleted);
            this.fsWatcher.Renamed += new System.IO.RenamedEventHandler(this.fsWatcher_Renamed);
            // 
            // eLog
            // 
            this.eLog.Log = "Application";
            this.eLog.Source = "AgentGSAService";
            // 
            // AgentGSAService
            // 
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.ServiceName = "AgentGSAService";
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eLog)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher fsWatcher;
        private System.Diagnostics.EventLog eLog;
    }
}
