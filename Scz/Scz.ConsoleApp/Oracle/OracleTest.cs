//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
//using System.Diagnostics;

//namespace ConsoleApp
//{
//    public class OracleTest
//    {
//        static string ConnString = "Data Source= (DESCRIPTION =     (ADDRESS_LIST =       (ADDRESS = (PROTOCOL = TCP)(HOST = 10.117.130.29)(PORT = 1521))     )     (CONNECT_DATA =       (SERVICE_NAME = ora29a)     )   );User ID=bmi14;Password=bmi14;";

//        public static void Test3()
//        {
//            Stopwatch stopWatch = new Stopwatch();

//            using (OracleConnection conn = new OracleConnection(ConnString))
//            {
                
//                string sql = @"SELECT *
//  FROM (SELECT ROW_.*, ROWNUM NUMROW
//          FROM (SELECT /*+  index(a IX_BILL_TABLE_HISID)  use_nl(a e d PATIENT RYLB CBLX ZDG)  leading(a) first_rows(100) */
//                 A.ID,
//                 A.TABLE_PAR,
//                 A.HISID,
//                 A.BILL_NO,
//                 A.CLAIM_TYPE,
//                 A.AUDIT_RESULT_F,
//                 A.AUDIT_RESULT_S,
//                 A.AUDIT_RESULT_L,
//                 A.ANDIT_MANU_STATUS,
//                 A.READ_FLAG,
//                 A.BILLDATE,
//                 A.FIRST_DATE,
//                 A.ADMISSION_DATE,
//                 A.DISCHARGE_DATE,
//                 A.PATIENT_BIRTH,
//                 A.PATIENT_SEX,
//                 A.PATIENT_NAME,
//                 A.HOSPITAL_NAME,
//                 A.HOSPITAL_ID,
//                 A.PATIENT_ID,
//                 A.ADMISSION_DISEASE_NAME,
//                 A.DISCHARGE_DISEASE_NAME,
//                 A.AUDIT_COMMENT_F,
//                 A.AUDIT_COMMENT_S,
//                 A.AUDIT_COMMENT_L,
//                 A.DUTY_IS_DOCTOR,
//                 A.DUTY_IS_PATIENT,
//                 A.DUTY_IS_HOSPITAL,
//                 A.DOCTOR_ID,
//                 A.TOTAL_AMOUNT,
//                 A.BMI_CONVERED_AMOUNT,
//                 A.BMI_NOPAY,
//                 A.HOSPITAL_COMPLAIN_STATUS,
//                 A.ADMISSION_NUMBER,
//                 A.MEDICALRECORD,
//                 A.OUTDEPT,
//                 A.AUDIT_COMMENT_REMARK,
//                 A.HOSPITAL_BACKS,
//                 NVL(A.TRICKSTATE, '0') AS TRICKSTATE,
//                 A.IS_RETRICK,
//                 A.BENEFIT_GROUP_ID,
//                 A.RULE_BIT,
//                 A.BMI_CODE,
//                 A.BENEFIT_TYPE AS BenefitTypeId,
//                 NVL(E.VARCHAR01, '') AS VARCHAR01,
//                 NVL(E.VARCHAR02, '') AS VARCHAR02,
//                 NVL(E.VARCHAR03, '') AS VARCHAR03,
//                 NVL(E.VARCHAR04, '') AS VARCHAR04,
//                 NVL(E.VARCHAR05, '') AS VARCHAR05,
//                 NVL(E.VARCHAR06, '') AS VARCHAR06,
//                 NVL(E.VARCHAR07, '') AS VARCHAR07,
//                 NVL(E.VARCHAR08, '') AS VARCHAR08,
//                 NVL(E.VARCHAR09, '') AS VARCHAR09,
//                 NVL(E.VARCHAR10, '') AS VARCHAR10,
//                 NVL(E.IXVARCHAR01, '') AS IXVARCHAR01,
//                 NVL(E.IXVARCHAR02, '') AS IXVARCHAR02,
//                 NVL(E.IXVARCHAR03, '') AS IXVARCHAR03,
//                 E.NUMBER01,
//                 E.NUMBER02,
//                 E.NUMBER03,
//                 E.NUMBER04,
//                 E.NUMBER05,
//                 E.NUMBER06,
//                 E.NUMBER07,
//                 E.NUMBER08,
//                 E.NUMBER09,
//                 E.IXNUMBER01,
//                 E.IXNUMBER02,
//                 E.IXNUMBER03,
//                 E.DATE01 AS DATE01,
//                 E.DATE02 AS DATE02,
//                 E.DATE03 AS DATE03,
//                 NVL(A.INDIVIDUAL_ACCOUNT, 0) INDIVIDUAL_ACCOUNT,
//                 NVL(A.SUPPLEMENTARY_PAYMENT, 0) SUPPLEMENTARY_PAYMENT,
//                 CASE
//                   WHEN A.SEC_FUND = 0 OR A.SEC_FUND IS NULL THEN
//                    CASE
//                      WHEN A.RETIREMENT_FUND = 0 OR A.RETIREMENT_FUND IS NULL THEN
//                       A.POOL_FUND
//                      ELSE
//                       A.RETIREMENT_FUND
//                    END
//                   ELSE
//                    A.SEC_FUND
//                 END AS POOL_FUND,
//                 A.RETIREMENT_FUND,
//                 A.RELIEF_FUND,
//                 A.MASONIC_FUND,
//                 A.CASH_PAYMENT,
//                 D.CLASS_NAME,
//                 D.P_ID,
//                 PATIENT.ID_NUMBER,
//                 PATIENT.BMINO,
//                 RYLB.CLASS_NAME AS BENEFITGROUPNAME,
//                 CBLX.CLASS_NAME AS BENEFIT_TYPE,
//                 ZDG.REGION_NAME AS REGION_NAME
//                  FROM DW_BILL A
//                  LEFT JOIN DW_BILL_EX E
//                    ON A.HISID = E.BILLID
//                   AND a.TABLE_PAR = e.TABLE_PAR
//                  LEFT JOIN DW_ZD_CLAIMTYPE D
//                    ON D.CLASS_ID = A.CLAIM_TYPE
//                  LEFT JOIN DW_ZD_PATIENT PATIENT
//                    ON PATIENT.ID = A.PATIENT_ID
//                  LEFT JOIN DW_ZD_BENEFITGROUP RYLB
//                    ON RYLB.CLASS_ID = A.BENEFIT_GROUP_ID
//                  LEFT JOIN DW_ZD_BENEFITPLAN CBLX
//                    ON CBLX.CLASS_ID = A.BENEFIT_TYPE
//                  LEFT JOIN DW_ZD_REGION ZDG
//                    ON A.BMI_CODE = ZDG.REGION_ID
//                 WHERE A.TABLE_PAR >= '20130102'
//                   AND A.TABLE_PAR <= '20130131'
//                   AND A.ANDIT_MANU_STATUS IN ('0', '1', '2', '9')
//                   AND A.BMI_CODE IN ('130124',
//                                      '330110',
//                                      '330100',
//                                      '330122',
//                                      '330127',
//                                      '330183',
//                                      '330185',
//                                      '130182',
//                                      '20110915000000000001',
//                                      '130185',
//                                      '330182',
//                                      '0571',
//                                      '330109')
//                   AND EXISTS (SELECT 1
//                          FROM DW_BILL_RULES R
//                         WHERE A.HISID = R.HISID
//                           AND A.TABLE_PAR = R.TABLE_PAR
//                           AND R.RULE_ID IN(519007,
//                                             251201,
//                                             287701,
//                                             531002,
//                                             519002,
//                                             519003,
//                                             519004,
//                                             519005,
//                                             519006,
//                                             531004,
//                                             100701,
//                                             100208,
//                                             120302,
//                                             120301,
//                                             120801,
//                                             130301,
//                                             130401,
//                                             130402,
//                                             120501,
//                                             120502,
//                                             100201,
//                                             100601,
//                                             100801,
//                                             100501,
//                                             101100,
//                                             100902,
//                                             100705,
//                                             100301,
//                                             100802,
//                                             100803,
//                                             100205,
//                                             100503,
//                                             150202,
//                                             150301,
//                                             150801,
//                                             150101,
//                                             140400,
//                                             140101,
//                                             140201,
//                                             150001,
//                                             100101,
//                                             0,
//                                             1,
//                                             120401,
//                                             150002,
//                                             101200,
//                                             100505,
//                                             100903,
//                                             140500,
//                                             150802,
//                                             15080204,
//                                             15080205,
//                                             15080206,
//                                             100104))
//                   AND A.HOSPITAL_ID IN
//                       (SELECT /*+ no_unnest*/
//                        DISTINCT BB.DETAIL_ID
//                          FROM SYS_USER_GP AA
//                         INNER JOIN SYS_GP_DETAIL BB
//                            ON AA.GP_ID = BB.GP_ID
//                         WHERE AA.USER_ID = '10510')
//                 ORDER BY A.TABLE_PAR, A.HISID) ROW_
//         WHERE ROWNUM <= 50)
// WHERE NUMROW > 0";

//                OracleCommand cmd = new OracleCommand(sql, conn);
//                conn.Open();

//                stopWatch.Start();
//                OracleDataReader dr = cmd.ExecuteReader();

//                stopWatch.Stop();
//                TimeSpan ts = stopWatch.Elapsed;

//                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
//                    ts.Hours, ts.Minutes, ts.Seconds,
//                    ts.Milliseconds / 10);
//                Console.WriteLine("RunTime " + elapsedTime);

//                stopWatch.Start();
//                while (dr.Read())
//                {
//                    Console.WriteLine("得到的结果为 : {0}", dr[0]);
//                }
//                dr.Close();

//                stopWatch.Stop();
//                TimeSpan ts2 = stopWatch.Elapsed;

//                string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
//                    ts2.Hours, ts2.Minutes, ts2.Seconds,
//                    ts2.Milliseconds / 10);
//                Console.WriteLine("RunTime2 " + elapsedTime2);

//            }

//            Console.Read();
//        }

//        public static void Test2()
//        {
//            double i = 65;
//            int j = Convert.ToInt32(i);

//            decimal result = (decimal)Math.Pow(2, i);

//            Console.WriteLine(string.Format("2的{0}次方", i));
//            Console.WriteLine(string.Format("没有转换：{0}", Math.Pow(2, i)));
//            Console.WriteLine(string.Format("转换后：{0}", result));


//            //long longResult = Convert.ToInt64(Math.Pow(2, i));
//            //Console.WriteLine(longResult.ToString());


//            using (OracleConnection conn = new OracleConnection(ConnString))
//            {
//                string sql = string.Format("select bitand(POWER(2, {0}),{1}) from dual", j, result);
//                OracleCommand cmd = new OracleCommand(sql, conn);
//                conn.Open();
//                OracleDataReader dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    string output = Convert.ToString((decimal)OracleDecimal.SetPrecision(dr.GetOracleDecimal(0), 28));

//                    Console.WriteLine("得到的结果为 : {0}", output);
//                    //Console.WriteLine("Id:{0}， UserName : {1}", dr["id"], dr["UserName"]);
//                }
//                dr.Close();
//            }

//            Console.Read();
//        }

//        public static void Test()
//        {
//            double i = 65;
//            int j = Convert.ToInt32(i);

//            double result = Math.Pow(2, i);

//            Console.WriteLine("-----------------");
//            Console.WriteLine(string.Format("2的{0}次方", i));
//            Console.WriteLine(string.Format("double 没有转换前：{0}",result.ToString()));
//            Console.WriteLine(string.Format("double 转换为decimal后：{0}", Convert.ToDecimal(result)));

//            //Console.WriteLine(string.Format("转换后：{0}", Convert.ToInt64(result)));


//            //long longResult = Convert.ToInt64(Math.Pow(2, i));
//            //Console.WriteLine(longResult.ToString());


//            using (OracleConnection conn = new OracleConnection(ConnString))
//            {
//                string sql = string.Format("select round(bitand(POWER(2, {0}),{1}),28) from dual",j, result);
//                OracleCommand cmd = new OracleCommand(sql, conn);
//                conn.Open();
//                OracleDataReader dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    long m1 = 0;
//                    //m1 = (long)dr.GetOracleValue(0);
//                    decimal m = (decimal)OracleDecimal.SetPrecision(dr.GetOracleDecimal(0), 28);
//                    string output = Convert.ToString(m);

//                    //string output = Convert.ToString(dr[0]);

//                    Console.WriteLine("得到 long 的结果为 : {0}", output);
//                    Console.WriteLine("得到 decimal 的结果为 : {0}",output );

//                    //Console.WriteLine("Id:{0}， UserName : {1}", dr["id"], dr["UserName"]);
//                }
//                dr.Close();
//            }

//            Console.Read();
//        }
//    }
//}
