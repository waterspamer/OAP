using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NXOpen;
using NXOpenUI;
using NXOpen.UF;
using NXOpen.Utilities;
using System.Windows.Forms;
using System.Collections;

namespace OAP_project
{
    static class Program
    {
        private static UFSession theUfSession;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static int Main(String[] args)
        {
            
            Application.Run(new Form1());
            int retValue = 0;
            return retValue++;
        }
        public static void MakeFingerPin(double d, double d1, double H, double h) {

            try
            {
                string name1 = "model_136";
                int units1 = 1;
                Tag UFPart1;
                theUfSession = UFSession.GetUFSession();
                theUfSession.Part.New(name1, units1, out UFPart1);
                double[] l1_endpt1 = { 0, 0, 0.0 };
                double[] l1_endpt2 = { 0, d / 2, 0.0 };
                double[] l2_endpt1 = { 0, d/2, 0.0 };
                double[] l2_endpt2 = { H-h, d / 2, 0.0 };
                double[] l3_endpt1 = { H-h, d/2, 0.0 };
                double[] l3_endpt2 = { H-h, d / 2-d1/2, 0.0 };
                double[] l4_endpt1 = { H - h, d / 2 - d1 / 2, 0.0 };
                double[] l4_endpt2 = { H, d / 2 - d1 / 2, 0.0 };
                double[] l5_endpt1 = { H, d / 2 - d1 / 2, 0.0 };
                double[] l5_endpt2 = { H, 0, 0.0 };
                double[] l6_endpt1 = { H, 0, 0.0 };
                double[] l6_endpt2 = { 0, 0, 0.0 };
                UFCurve.Line line1 = new UFCurve.Line();
                UFCurve.Line line2 = new UFCurve.Line();
                UFCurve.Line line3 = new UFCurve.Line();
                UFCurve.Line line4 = new UFCurve.Line();
                UFCurve.Line line5 = new UFCurve.Line();
                UFCurve.Line line6 = new UFCurve.Line();
                SetPointsToLine(ref line1, l1_endpt1, l1_endpt2);
                SetPointsToLine(ref line2, l2_endpt1, l2_endpt2);
                SetPointsToLine(ref line3, l3_endpt1, l3_endpt2);
                SetPointsToLine(ref line4, l4_endpt1, l4_endpt2);
                SetPointsToLine(ref line5, l5_endpt1, l5_endpt2);
                SetPointsToLine(ref line6, l6_endpt1, l6_endpt2);
                Tag[] objarray1 = new Tag[9];
                theUfSession.Curve.CreateLine(ref line1, out objarray1[0]);
                theUfSession.Curve.CreateLine(ref line2, out objarray1[1]);
                theUfSession.Curve.CreateLine(ref line3, out objarray1[2]);
                theUfSession.Curve.CreateLine(ref line4, out objarray1[3]);
                theUfSession.Curve.CreateLine(ref line5, out objarray1[4]);
                theUfSession.Curve.CreateLine(ref line6, out objarray1[5]);
                double[] ref_pt1 = new double[3];
                ref_pt1[0] = 0.00;
                ref_pt1[1] = 0.00;
                ref_pt1[2] = 0.00;
                double[] direction1 = { 1.00, 0.00, 0.00 };
                string[] limit1 = { "0", "360" };
                Tag[] features1;
                theUfSession.Modl.CreateRevolved(objarray1, limit1, ref_pt1, direction1, FeatureSigns.Nullsign, out features1);
                Tag feat = features1[0];
                Tag cyl_tag, obj_id_camf, blend1, s_face, c_face;
                Tag[] Edge_array_cyl, list1, list2;
                int ecount;

                //анализ ребер рассматриваемой детали
                theUfSession.Modl.AskFeatBody(feat, out cyl_tag);
                theUfSession.Modl.AskBodyEdges(cyl_tag, out Edge_array_cyl);
                theUfSession.Modl.AskListCount(Edge_array_cyl, out ecount);
                ArrayList arr_list1 = new ArrayList();
                ArrayList arr_list2 = new ArrayList();//фаски
                for (int ii = 0; ii < ecount; ii++)
                {
                    Tag edge;
                    theUfSession.Modl.AskListItem(Edge_array_cyl, ii, out edge);

                    if (ii == 2)
                    {
                        arr_list2.Add(edge);
                    }
                    if (ii == 3) {
                        arr_list1.Add(edge);
                    }

                }
                list1 = (Tag[])arr_list1.ToArray(typeof(Tag));
                list2 = (Tag[])arr_list2.ToArray(typeof(Tag));

                //фаска

                string offset1 = "1";
                string offset2 = "1";
                string offset11 = "0.5";
                string offset21 = "0.5";
                string ang = "45";
                theUfSession.Modl.CreateChamfer(3, offset1, offset2, ang, list1, out obj_id_camf);
                theUfSession.Modl.CreateChamfer(3, offset11, offset21, ang, list2, out obj_id_camf);

            }
            catch (NXException ex) { }
            }
        public static void MakePin(double d, double c, double l) {

            try
            {
                string name1 = "model_125";
                int units1 = 1;
                Tag UFPart1;
                theUfSession = UFSession.GetUFSession();
                theUfSession.Part.New(name1, units1, out UFPart1);
                double d1 = d + l / 50;
                double[] l1_endpt1 = { 0, 0, 0.0 };
                double[] l1_endpt2 = { 0, d / 2, 0.0 };
                double[] l2_endpt1 = { 0, d / 2, 0.0 };
                double[] l2_endpt2 = { l, d1 / 2, 0.0 };
                double[] l3_endpt1 = { l, d1 / 2, 0.0 };
                double[] l3_endpt2 = { l, 0, 0.0 };
                double[] l4_endpt1 = { l, 0, 0.0 };
                double[] l4_endpt2 = { 0, 0, 0.0 };
                UFCurve.Line line1 = new UFCurve.Line();
                UFCurve.Line line2 = new UFCurve.Line();
                UFCurve.Line line3 = new UFCurve.Line();
                UFCurve.Line line4 = new UFCurve.Line();
                SetPointsToLine(ref line1, l1_endpt1, l1_endpt2);
                SetPointsToLine(ref line2, l2_endpt1, l2_endpt2);
                SetPointsToLine(ref line3, l3_endpt1, l3_endpt2);
                SetPointsToLine(ref line4, l4_endpt1, l4_endpt2);
                Tag[] objarray1 = new Tag[9];
                theUfSession.Curve.CreateLine(ref line1, out objarray1[0]);
                theUfSession.Curve.CreateLine(ref line2, out objarray1[1]);
                theUfSession.Curve.CreateLine(ref line3, out objarray1[2]);
                theUfSession.Curve.CreateLine(ref line4, out objarray1[3]);
                double[] ref_pt1 = new double[3];
                ref_pt1[0] = 0.00;
                ref_pt1[1] = 0.00;
                ref_pt1[2] = 0.00;
                double[] direction1 = { 1.00, 0.00, 0.00 };
                string[] limit1 = { "0", "360" };
                Tag[] features1;
                theUfSession.Modl.CreateRevolved(objarray1, limit1, ref_pt1, direction1, FeatureSigns.Nullsign, out features1);

                Tag feat = features1[0];
                Tag cyl_tag, obj_id_camf, blend1, s_face, c_face;
                Tag[] Edge_array_cyl, list1, list2;
                int ecount;

                //анализ ребер рассматриваемой детали
                theUfSession.Modl.AskFeatBody(feat, out cyl_tag);
                theUfSession.Modl.AskBodyEdges(cyl_tag, out Edge_array_cyl);
                theUfSession.Modl.AskListCount(Edge_array_cyl, out ecount);
                ArrayList arr_list2 = new ArrayList();//фаски
                for (int ii = 0; ii < ecount; ii++)
                {
                    Tag edge;
                    theUfSession.Modl.AskListItem(Edge_array_cyl, ii, out edge);
                   
                    if (ii > -1)
                    {
                        arr_list2.Add(edge);
                    }

                }

                list2 = (Tag[])arr_list2.ToArray(typeof(Tag));

                //фаска

                string offset1 = c.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                string offset2 = c.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                string ang = "45";
                theUfSession.Modl.CreateChamfer(3, offset1, offset2, ang, list2, out obj_id_camf);
               // theUfSession.Part.Save();
            }
            catch (NXException ex) { }
            }
        public static void MakeHandle(double L, double L1,double d1,double d2,double l) {

            try
            {
                string name1 = "model_56";
                int units1 = 1;
                Tag UFPart1;
                theUfSession = UFSession.GetUFSession();
                theUfSession.Part.New(name1, units1, out UFPart1);

                double[] l1_endpt1 = { 0, d2 / 2, 0.0 };
                double[] l1_endpt2 = { L-L1-l, d2 / 2, 0.0 };
                double[] l2_endpt1 = { L - L1 - l, d2 / 2, 0.0 };
                double[] l2_endpt2 = { L - L1 - l, d1/2, 0.0 };
                double[] l3_endpt1 = { L - L1 - l, d1 / 2, 0.0 };
                double[] l3_endpt2 = { L - l, d1 / 2, 0.0 };
                double[] l4_endpt1 = { L - l, d1 / 2, 0.0 };
                double[] l4_endpt2 = { L-l, d2 / 2, 0.0 };
                double[] l5_endpt1 = { L - l, d2 / 2, 0.0 };
                double[] l5_endpt2 = { L , d2 / 2, 0.0 };
                double[] l6_endpt1 = { L, d2 / 2, 0.0 };
                double[] l6_endpt2 = { L, 0, 0.0 };
                double[] l7_endpt1 = { L, 0, 0.0 };
                double[] l7_endpt2 = { 0, 0, 0.0 };
                double[] l8_endpt1 = { 0, 0, 0.0 };
                double[] l8_endpt2 = { 0, d2 / 2, 0.0 };
                UFCurve.Line line1 = new UFCurve.Line();
                UFCurve.Line line2 = new UFCurve.Line();
                UFCurve.Line line3 = new UFCurve.Line();
                UFCurve.Line line4 = new UFCurve.Line();
                UFCurve.Line line5 = new UFCurve.Line();
                UFCurve.Line line6 = new UFCurve.Line();
                UFCurve.Line line7 = new UFCurve.Line();
                UFCurve.Line line8 = new UFCurve.Line();
                SetPointsToLine(ref line1, l1_endpt1, l1_endpt2);
                SetPointsToLine(ref line2, l2_endpt1, l2_endpt2);
                SetPointsToLine(ref line3, l3_endpt1, l3_endpt2);
                SetPointsToLine(ref line4, l4_endpt1, l4_endpt2);
                SetPointsToLine(ref line5, l5_endpt1, l5_endpt2);
                SetPointsToLine(ref line6, l6_endpt1, l6_endpt2);
                SetPointsToLine(ref line7, l7_endpt1, l7_endpt2);
                SetPointsToLine(ref line8, l8_endpt1, l8_endpt2);
                Tag[] objarray1 = new Tag[9];
                theUfSession.Curve.CreateLine(ref line1, out objarray1[0]);
                theUfSession.Curve.CreateLine(ref line2, out objarray1[1]);
                theUfSession.Curve.CreateLine(ref line3, out objarray1[2]);
                theUfSession.Curve.CreateLine(ref line4, out objarray1[3]);
                theUfSession.Curve.CreateLine(ref line5, out objarray1[4]);
                theUfSession.Curve.CreateLine(ref line6, out objarray1[5]);
                theUfSession.Curve.CreateLine(ref line7, out objarray1[6]);
                theUfSession.Curve.CreateLine(ref line8, out objarray1[7]);

                double[] ref_pt1 = new double[3];
                ref_pt1[0] = 0.00;
                ref_pt1[1] = 0.00;
                ref_pt1[2] = 0.00;
                double[] direction1 = { 1.00, 0.00, 0.00 };
                string[] limit1 = { "0", "360" };
                Tag[] features1;
                theUfSession.Modl.CreateRevolved(objarray1, limit1, ref_pt1, direction1, FeatureSigns.Nullsign, out features1);
                theUfSession.Part.Save();
            }
            catch (NXException ex) { }
            }
        public static void SetPointsToLine(ref UFCurve.Line line, double[] l_endpt1, double[] l_endpt2)
        {
            line.start_point = new double[3];
            line.start_point[0] = l_endpt1[0];
            line.start_point[1] = l_endpt1[1];
            line.start_point[2] = l_endpt1[2];
            line.end_point = new double[3];
            line.end_point[0] = l_endpt2[0];
            line.end_point[1] = l_endpt2[1];
            line.end_point[2] = l_endpt2[2];
        }
    }
    
}
