namespace AgentPublishGSA
{
    partial class ProjectInstaller
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
            this.serviceGSAProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceGSAInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceGSAProcessInstaller
            // 
            this.serviceGSAProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceGSAProcessInstaller.Password = null;
            this.serviceGSAProcessInstaller.Username = null;
            // 
            // serviceGSAInstaller
            // 
            this.serviceGSAInstaller.Description = "Agent of GSA for Publishing Aid";
            this.serviceGSAInstaller.DisplayName = "Agent GSA Publishing";
            this.serviceGSAInstaller.ServiceName = "AgentGSAService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceGSAProcessInstaller,
            this.serviceGSAInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceGSAProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceGSAInstaller;
    }
}