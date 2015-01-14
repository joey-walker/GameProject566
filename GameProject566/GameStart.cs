using System;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameProject566
{
	public class GameStart : System.Windows.Forms.Form
	{
		private Device device;
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


		public void InitializeDevice(){
			PresentParameters dx_params = new PresentParameters ();
			/*

			The runtime guarantees the implied semantics concerning buffer swap behavior. 
			So if Windowed is set to true and SwapEffect is set to SwapEffect.Flip, 
			the runtime creates one extra back buffer and copies whichever becomes the front buffer at presentation time.

			The SwapEffect.Copy setting requires that BackBufferCount be set to 1. 
			This setting is enforced in the debug runtime, which fills any buffer with noise after it is presented.
			*/
			dx_params.SwapEffect = SwapEffect.Discard;

			// Make app windowed.
			dx_params.Windowed = true;

			//0 is first GPU
			device = new Device (0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, dx_params);
		}
	}
}

