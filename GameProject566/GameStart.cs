using System;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;

namespace GameProject566
{
	public class GameStart : System.Windows.Forms.Form
	{
		
		private IContainer container = null;

		public GameStart()
		{
			InitializeComponent ();
		}


		private void InitializeComponent(){

			this.container = new Container ();
			this.Size = new System.Drawing.Size (1024, 768);
			this.Text = "Dreadnought Kamzhor";
		}


		public static void Main ()
		{
		
			/* using -> New concept, Basically it creates objects that if disposable will
			 * get rid of the object when no longer being managed.
			 * The rest creates a standard windows form that we tell the application to run.
			 */

			using (GameStart dx_form = new GameStart ()) {
				Application.Run (dx_form);
			}


		}


		//Need to override dispose to get rid of custom container

		protected override void Dispose(bool disposing){

			if (disposing) {
				if (container != null) {
					container.Dispose ();
				}

			}

			base.Dispose (disposing);
		}
	}
}

