/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 6/15/2024
 * Time: 6:45 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace circleGeometry
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public class linie
		{
			public float x1;
			public float y1;
			public float x2;
			public float y2;
			public Color bkgr = Color.White;
			public Color frgd = Color.Black;
			public linie(){}
			public linie(float px1, float py1, float px2, float py2)
			{
				x1=px1;
				y1=py1;
				x2=px2;
				y2=py2;
			}
		}
			
		public class cerc
		{
			public float leftpointx = 0;
			public float toppointy = 0;
			public float centerpointx = 0;
			public float centerpointy = 0;
			public float radiusx = 0;
			public float radiusy = 0;
			public float diameterx = 0;
			public float diametery = 0;
			public float circumference = 0;
			public float lengthofcircle = 0;
			public float excentricity = 0;
			public Color bkgr = Color.White;
			public Color frgd = Color.Black;
			public cerc()
			{
			}
			public cerc(float pl, float pt, float diamx, float diamy)
			{
				leftpointx = pl;
				toppointy = pt;
				diameterx = diamx;
				diametery = diamy;
			}
			public void calculateCenterOfCircle()
			{
				this.radiusx = (diameterx/2);
				this.centerpointx = leftpointx + radiusx;
				
				this.radiusy = (diametery/2);
				this.centerpointy = toppointy + radiusy;
			}
		}
		public class grafica
		{
			public Graphics g;
			public void setG(ref Graphics pg)
			{
				g = pg;
			}
			public void initG(ref Form o)
			{
				g = o.CreateGraphics();
			}
			public void initG(Form o)
			{
				g = o.CreateGraphics();
			}
			public void initG(ref Panel o)
			{
				g = o.CreateGraphics();
			}
			public Font f;
			public void setF(ref Font pf)
			{
				f = pf;
			}
			public void initF(ref Form o)
			{
				f = o.Font;
			}
			public void initF(Form o)
			{
				f = o.Font;
			}
			public Brush b = new SolidBrush(Color.Black);
			public Pen p = new Pen(Color.Black, 1);
			
		}
		public class draw
		{
			public draw()
			{
			}
			public void drawCerc(ref Graphics ppg, ref cerc c0, ref grafica pgr)
			{
				
				ppg.DrawEllipse(pgr.p, c0.leftpointx, c0.toppointy, c0.diameterx, c0.diametery);
			}
			public void drawLine(ref Graphics ppg, ref cerc c0, ref grafica pgr)
			{
				
				ppg.DrawLine(pgr.p, c0.leftpointx, c0.toppointy, c0.leftpointx+c0.diameterx, c0.toppointy+c0.diametery);
			
			}
			public void drawLine(ref Graphics ppg,ref linie l, ref grafica pgr)
			{
				
				ppg.DrawLine(pgr.p, l.x1, l.y1, l.x2, l.y2);
			
			}
			public void drawRectangle(ref Graphics ppg, ref cerc c0, ref grafica pgr)
			{
				
				ppg.DrawRectangle(pgr.p, c0.leftpointx, c0.toppointy, c0.diameterx, c0.diametery);
				
			}
			public void clearAll(ref grafica pgr, ref cerc c0)
			{
				
				pgr.g.Clear(c0.bkgr);
				
			}
		}
		public grafica gf = new grafica();
		public draw dr = new draw();
			
		public cerc c1 = new cerc(100, 100, 50, 50);
		public cerc c2 = new cerc(110, 310, 30, 30);
		public cerc c3 = new cerc(425, 125, 50, 50);
		public cerc c4 = new cerc(350, 150, 50, 50);
		public linie l1 = new linie(100,100,0,0);
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
				gf.initG(this);
		}
		void Button1Click(object sender, EventArgs e)
		{
			
			
			dr.clearAll(ref gf,ref c1);
			
			dr.drawCerc(ref gf.g, ref c1, ref gf);
			dr.drawCerc(ref gf.g, ref c2, ref gf);
			dr.drawCerc(ref gf.g, ref c3, ref gf);
			dr.drawCerc(ref gf.g, ref c4, ref gf);
			
			dr.drawRectangle(ref gf.g, ref c1, ref gf);
			dr.drawRectangle(ref gf.g, ref c2, ref gf);
			dr.drawRectangle(ref gf.g, ref c3, ref gf);
			dr.drawRectangle(ref gf.g, ref c4, ref gf);
			
			dr.drawLine(ref gf.g, ref c1, ref gf);
			dr.drawLine(ref gf.g, ref c2, ref gf);
			dr.drawLine(ref gf.g, ref c3, ref gf);
			dr.drawLine(ref gf.g, ref c4, ref gf);
			
			c1.calculateCenterOfCircle();
			c2.calculateCenterOfCircle();
			c3.calculateCenterOfCircle();
			c4.calculateCenterOfCircle();
			
			l1.x2 = c1.centerpointx;
			l1.y2 = c1.centerpointy;
			dr.drawLine(ref gf.g, ref l1, ref gf);
		}
	}
}
