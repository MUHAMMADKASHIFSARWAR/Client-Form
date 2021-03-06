 SELECT   
  
 distinct
 a.CLIENT,
 a.docrefno,
 PLC_DESC,
 PM.PRODUCER,  
 
 SUM(NP1)NP100,SUM(KNOCKOFF)KNOCK,PDP_DESC  
 FROM  
 (SELECT DISTINCT   
                 outstanding.seq AS seq,  
                 outstanding.gcd_share,  
                 substring(outstanding.client_code,1,CASE '0' WHEN '0' THEN '20' ELSE '0' END)  AS client_code,  
                 outstanding.pdt_doctype,  
                 outstanding.client AS client,  
                 outstanding.plc_loc_code AS plc_loc_code,  
                 outstanding.plc_desc AS plc_desc,  
                 outstanding.pdp_dept_code AS pdp_dept_code,  
                 outstanding.pdp_desc AS pdp_desc,  
                 outstanding.gdh_individual_client AS gdh_individual_client,  
                 outstanding.docrefno AS docrefno,  
                 outstanding.docref AS docref,  
                 outstanding.agent_code AS agent_code,  
                 outstanding.basedocumentno AS basedocumentno,  
                 outstanding.gdh_as400_documentno AS gdh_as400_documentno,  
                 outstanding.folio_code AS folio_code,  
                 outstanding.posttag AS posttag,  
                 outstanding.commdate AS commdate,  
                 outstanding.issuedate AS issuedate,  
                 outstanding.expdate AS expdate,  
                 COALESCE (outstanding.np1, 0) AS np1,  
                 COALESCE (outstanding.np, 0) AS np,  
                 COALESCE (outstanding.gp_our, 0) AS gp_our,  
                 COALESCE (outstanding.gp100, 0) AS gp100,  
                 outstanding.ggd_leaderreference AS ggd_leaderreference,  
                 outstanding.AGENT AS AGENT, outstanding.folio AS folio,  
                 outstanding.pdo_devoffcode AS pdo_devoffcode,  
                 outstanding.pdo_devoffdesc AS pdo_devoffdesc,  
                 COALESCE (outstanding.knockoff, 0) AS knockoff,  
                 COALESCE (outstanding.opening, 0) AS opening,  
                 COALESCE (outstanding.advances, 0) AS advances  
            FROM (SELECT   1 AS seq, 1 gcd_share, op.pps_party_code AS client_code,'A1' pdt_doctype,  
                           op.pps_desc AS client, op.loc AS plc_loc_code,  
                           br.plc_desc AS plc_desc, NULL AS pdp_dept_code,  
                           NULL AS pdp_desc, NULL AS docrefno, NULL AS docref,  
                           NULL AS agent_code, NULL AS basedocumentno,  
                           NULL AS gdh_as400_documentno, NULL AS folio_code,  
                           NULL AS gdh_individual_client, NULL AS posttag,  
                           NULL AS commdate, NULL AS issuedate,  
                           NULL AS expdate, 0 AS np1, 0 AS np, 0 AS gp_our,  
                           0 AS gp100, NULL AS ggd_leaderreference,  
                           NULL AS AGENT, NULL AS folio,  
                           NULL AS pdo_devoffcode, NULL AS pdo_devoffdesc,  
                           0 AS knockoff,  
                           SUM (COALESCE (op.open_bal, 0)) AS opening,  
                           0 AS advances  
                      FROM   
 (  
 SELECT q.pps_party_code, q.pps_desc, q.vchddate vchddate,  
           (COALESCE (q.a1, 0) - COALESCE (q.b1, 0)) open_bal, q.org, q.loc  
      FROM (SELECT   a.org, a.loc, a.pps_party_code, a.pps_desc, a.vchddate,  
                     SUM (CASE a.pad_advtcode  
                             WHEN 'ORBA'  
                                THEN COALESCE (a.bal, 0)  
                             ELSE 0  
                          END  
                         ) a1,  
                     SUM (CASE a.pad_advtcode  
                             WHEN 'OPBA'  
                                THEN COALESCE (a.bal, 0)  
                             ELSE 0  
                          END  
                         ) b1  
                FROM (SELECT sb.por_orgacode org, sb.plc_locacode loc,  
                             sl.psa_sactaccount pps_party_code, pp.pps_desc,  
                             sb.lpm_rmstdate vchddate, sl.pad_advtcode,  
                               COALESCE (sl.lsl_sldramtbc, 0) +
                              - COALESCE ( (  
                               select ABS(SUM(COALESCE(VD.LVD_VCDTCRAMTBC,0) - COALESCE(VD.LVD_VCDTDRAMTBC,0) )) from ac_gl_vd_vchdetail vd,ac_gl_vh_voucher v   
                               where vd.POR_ORGACODE=v.POR_ORGACODE and   
                                     vd.PLC_LOCACODE=v.PLC_LOCACODE and   
                                     vd.PVT_VCHTTYPE= v.PVT_VCHTTYPE and   
                                     vd.PFS_ACNTYEAR = v.PFS_ACNTYEAR and   
                                     vd.LVH_VCHDNO = v.LVH_VCHDNO AND   
                                     COALESCE(V.LVH_VCHDSTATUS,'N') <>'C' AND  
                                     V.LVH_VCHDDATE <=' 01-jan-2000 ' AND  
                                     VD.PLC_LOCACODE=SL.PLC_LOCACODE AND     
                                     VD.LVD_VCDTNARRATION1=SL.PFS_ACNTYEAR||'-'||SL.PAD_ADVTCODE||'-'||SL.LPM_RMSTNO||'-'||SL.LPD_RDTLSRNO ||'-'||SL.LSL_SLDRNO  
                               ),0) BAL  
              FROM ac_gl_sl_subledger sl INNER JOIN pr_gn_ps_party pp  
                             ON (pp.pps_party_code = sl.psa_sactaccount)  
                             INNER JOIN ac_gl_pm_rcppymmaster sb  
                             ON (    sb.por_orgacode = sl.por_orgacode  
                                 AND sb.plc_locacode = sl.plc_locacode  
                                 AND sb.pad_advtcode = sl.pad_advtcode  
                                 AND sb.pfs_acntyear = sl.pfs_acntyear  
                                 AND sb.lpm_rmstno = sl.lpm_rmstno  
                                )  
                       WHERE sl.pad_advtcode IN ('ORBA', 'OPBA')  
                       AND COALESCE(SB.LPM_RMSTSTATUS,'N')<>'C' )a  
                       group by a.org, a.loc, a.pps_party_code, a.pps_desc, a.vchddate  
                       )q  
 ) op INNER JOIN pr_gn_lc_location br  
                           ON (    op.org = br.por_orgacode  
                               AND op.loc = br.plc_locacode  
                              )  
                           INNER JOIN pr_gn_ps_party p  
                           ON (p.pps_party_code = substring(op.pps_party_code,1,CASE '0' WHEN '0' THEN '20' ELSE '0' END))  
                     WHERE op.vchddate < = '01-jan-2000'  
                       AND p.pps_nature = 'C'  
 GROUP BY op.pps_party_code, op.pps_desc, op.loc, br.plc_desc  
                    HAVING SUM (COALESCE (op.open_bal, 0)) <> 0  
                  UNION  
                  SELECT 2 AS seq,   
 CASE own_share_tag  
                            WHEN 'Y'  
                               THEN 100  
                            ELSE coalesce(cd.gcd_share,100) end gcd_share,  
 CASE WHEN own_share_tag = 'Y'  AND  h.piy_insutype='I' THEN COALESCE(H.CLIENT_CODE,'N') ELSE  COALESCE(H.FOLIO_CODE,'N') end AS client_code,  
 h.pdt_doctype,pt.pps_desc client, h.plc_loc_code AS plc_loc_code,  
                         lc.plc_desc AS plc_desc,  
                         h.pdp_dept_code AS pdp_dept_code,  
                         dp.pdp_desc AS pdp_desc, h.docrefno AS docrefno,  
                         cl.docref AS docref, h.agent_code AS agent_code,  
                         h.basedocumentno AS basedocumentno,  
                         h.gdh_as400_documentno AS gdh_as400_documentno,  
                         h.folio_code AS folio_code,  
                         h.gdh_individual_client AS gdh_individual_client,  
                         h.posttag AS posttag, h.commdate AS commdate,  
                         h.issuedate AS issuedate, h.expdate AS expdate,  
                         CASE own_share_tag  
                            WHEN 'Y'  
                               THEN COALESCE (h.netprem, 0)  
                            ELSE h.np100  
                         END AS np1,  
                         COALESCE (h.netprem, 0) AS np, h.grossprem AS gp_our,  
                         CASE own_share_tag  
                            WHEN 'Y'  
                               THEN COALESCE (h.grossprem, 0)  
                            ELSE h.gp100  
                         END AS gp100,  
                         h.ggd_leaderreference AS ggd_leaderreference,  
                         agt.pps_desc AS AGENT, pft.pps_desc AS folio,  
                         COALESCE (h.pdo_devoffcode, '12XX') pdo_devoffcode,  
                         COALESCE (DO.pdo_devoffdesc, 'All') AS pdo_devoffdesc,  
                         COALESCE (cl.koff, 0) AS knockoff, 0 AS opening,  
                         0 AS advances  
                    FROM premium_view h  
                         LEFT OUTER JOIN  
                         (SELECT   docref, policy_no,  
                                   COALESCE (SUM (knockoffamount), 0) koff  
                              FROM collection_table  
                             WHERE vchdate <=  
                                          '06-may-2019'  
                          GROUP BY docref, policy_no) cl  
                         ON (    h.docrefno = cl.docref  
                             AND (CASE h.pdt_doctype  
                                     WHEN 'E'  
                                        THEN h.basedocumentno  
                                     ELSE 'n'  
                                  END  
                                 ) =  
                                    (CASE h.pdt_doctype  
                                        WHEN 'E'  
                                           THEN cl.policy_no  
                                        ELSE 'n'  
                                     END  
                                    )  
                            )  
                         LEFT OUTER JOIN pr_gg_do_devofficer DO  
                         ON (    h.pdo_devoffcode = DO.pdo_devoffcode  
                            
                            )  
                         INNER JOIN pr_gn_dp_department dp  
                         ON (    h.plc_loc_code = dp.plc_loc_code  
                             AND h.pdp_dept_code = dp.pdp_dept_code  
                            ) LEFT OUTER JOIN GI_GU_DH_DOC_HEADER EH  
 ON (  
 H.BASEDOCUMENTNO=EH.GDH_DOC_REFERENCE_NO   
 AND H.GDH_RECORD_TYPE=EH.GDH_RECORD_TYPE   
 )  
                         INNER JOIN pr_gn_lc_location lc  
                         ON (h.plc_loc_code = lc.plc_loc_code)  
                         LEFT OUTER JOIN pr_gn_ps_party agt  
                         ON (h.agent_code = agt.pps_party_code)  
                         left outer JOIN pr_gn_ps_party pt  
                         ON (CASE own_share_tag  WHEN 'Y'  THEN COALESCE(H.CLIENT_CODE,'N') ELSE  COALESCE(H.FOLIO_CODE,'N') end  = pt.pps_party_code)  
                         LEFT OUTER JOIN pr_gn_ps_party pft  
                         ON (h.folio_code = pft.pps_party_code)  
 left outer join PR_GG_BC_BUSINESS_CLASS bc on   
                         (h.PBC_BUSICLASS_CODE=bc.PBC_BUSICLASS_CODE  )  
 left outer join  
 GI_GU_CD_COINSURERDTL CD  on (  
 H.POR_ORG_CODE      = CD.POR_ORG_CODE         AND   
 H.PLC_LOC_CODE      = CD.PLC_LOC_cODE         AND   
 H.PDP_DEPT_CODE     = CD.PDP_DEPT_cODE        AND    
 H.PBC_BUSICLASS_CODE = CD.PBC_BUSICLASS_CODE  AND   
 H.PIY_INSUTYPE      = CD.PIY_INSUTYPE         AND   
 H.PDT_DOCTYPE       = CD.PDT_DOCTYPE          AND    
 H.GDH_DOCUMENTNO    = CD.GDH_DOCUMENTNO       AND   
 H.GDH_RECORD_TYPE   = CD.GDH_RECORD_TYPE      AND   
 H.GDH_YEAR          = CD.GDH_YEAR       AND  CD.GCD_LEADERTAG    = 'Y')  
                   WHERE COALESCE (h.gdh_oldmaster_ref_no, 'N') <>'net off pb cases'  
                     AND h.por_org_code = '001001'    
                      AND h.issuedate BETWEEN '01-jan-2000'  AND '06-May-2019'  
 AND case PBC_OPENPOLICY_FINANCIALIMPACT when 'Y' THEN 'P' ELSE CASE H.PDT_DOCTYPE WHEN 'E' THEN EH.PDT_DOCTYPE ELSE  H.PDT_DOCTYPE  END END <>'O'  
 AND CASE own_share_tag WHEN 'Y' THEN 'D' ELSE h.piy_insutype END NOT IN ('I', 'A')  
                      AND COALESCE(H.POSTTAG,'N')=CASE 'Y' WHEN 'Y' THEN 'Y' WHEN 'N' THEN 'N' ELSE COALESCE('Y','N') END    
 and  (CASE own_share_tag WHEN 'Y' THEN COALESCE (h.netprem, 0) ELSE h.np100 END  -   COALESCE (cl.koff, 0) )  <>  0  
 UNION   
 select   
     adv.seq as seq ,1 gcd_share,  
     adv.client_code as  client_code,adv.pdt_doctype,  
     ins.pps_desc as client,    
     adv.plc_locacode as plc_locacode ,  
     br.plc_desc as  plc_desc     ,  
     NULL AS pdp_dept_code,  
                           NULL AS pdp_desc, NULL AS docrefno, NULL AS docref,  
                           NULL AS agent_code, NULL AS basedocumentno,  
                           NULL AS gdh_as400_documentno, NULL AS folio_code,  
                           NULL AS gdh_individual_client, NULL AS posttag,  
                           NULL AS commdate, NULL AS issuedate,  
                           NULL AS expdate, 0 AS np1, 0 AS np, 0 AS gp_our,  
                           0 AS gp100, NULL AS ggd_leaderreference,  
                           NULL AS AGENT, NULL AS folio,  
                           NULL AS pdo_devoffcode, NULL AS pdo_devoffdesc,  
                           0 AS knockoff, 0 AS opening,  
     sum(coalesce(adv.advances,0)) as advances   
 from   
 (  
 select   
       3 AS seq,     
       submas.PSA_SACTACCOUNT as client_code, 'A1' pdt_doctype,  
       submas.plc_locacode as plc_locacode,     
       coalesce(submas.lsm_smstbalcrbc,0) - coalesce(submas.lsm_smstbaldrbc,0) as advances    
       from AC_GL_SM_SUBMASTER submas  
 where   
  substring(submas.PFS_ACNTYEAR,1,4) =   '2019'      
 and submas.pca_glaccode IN (SELECT m_code  
                                                 FROM gias_prm_mapping  
                                                WHERE m_type = 55)  
 and submas.ppd_perdno = 0       
 union                 
                  SELECT     
                         3 AS seq,   
                         sd.psa_sactaccount as client_code,'A1' pdt_doctype,  
                           sd.plc_locacode as plc_locacode ,     
                             
                           (  SUM (COALESCE (sd.lsb_sdtlcramtbc, 0))  
                            - SUM (COALESCE (sd.lsb_sdtldramtbc, 0))  
                           ) AS advances  
                      FROM ac_gl_vh_voucher vh INNER JOIN ac_gl_vd_vchdetail vd  
                           ON (    vh.por_orgacode = vd.por_orgacode  
                               AND vh.plc_locacode = vd.plc_locacode  
                               AND vh.pvt_vchttype = vd.pvt_vchttype  
                               AND vh.pfs_acntyear = vd.pfs_acntyear  
                               AND vh.lvh_vchdno = vd.lvh_vchdno  
                            )  
                           INNER JOIN ac_gl_sb_subdetail sd  
                           ON (    vd.por_orgacode = sd.por_orgacode  
                               AND vd.plc_locacode = sd.plc_locacode  
                               AND vd.pvt_vchttype = sd.pvt_vchttype  
                               AND vd.pfs_acntyear = sd.pfs_acntyear  
                               AND vd.lvh_vchdno = sd.lvh_vchdno  
                               AND vd.lvd_vcdtvouchsr = sd.lvd_vcdtvouchsr  
                              )  
                                
                                
                           INNER JOIN pr_gn_ps_party p  
                           ON (substring(sd.psa_sactaccount,1,CASE '0' WHEN '0' THEN '20' ELSE '0' END) = p.pps_party_code)  
                             
                     WHERE vh.lvh_vchdstatus IN ('P', 'V')  
                       AND vh.lvh_vchddate <= '06-May-2019'   
                       
                       AND to_char(vh.lvh_vchddate,'YYYY') =   '2019'     
                       AND COALESCE (vh.lvh_vchdautomanual, 'M') IN ('A', 'M')  
                       AND vd.pca_glaccode IN (SELECT m_code  
                                                 FROM gias_prm_mapping  
                                                WHERE m_type = 55)  
                       AND p.pps_nature = 'C'   
                  GROUP BY sd.psa_sactaccount,  
                           p.pps_desc,  
                           sd.plc_locacode                          
                    HAVING (  SUM (COALESCE (sd.lsb_sdtlcramtbc, 0))  
                            - SUM (COALESCE (sd.lsb_sdtldramtbc, 0))  
                           ) <> 0  
                           ) adv inner join pr_gn_ps_party ins on (  
                           ins.pps_party_code = substring(adv.client_code,1,CASE '0' WHEN '0' THEN '20' ELSE '0' END)   
                           and ins.pps_nature = 'C'    
                                                     ) inner join pr_gn_lc_location br on (  
                           br.plc_locacode = adv.plc_locacode      
                                                       
                                                     ) Group By   
     adv.seq ,  
     adv.client_code  ,adv.pdt_doctype,  
     ins.pps_desc  ,   
     adv.plc_locacode ,  
     br.plc_desc        
     ) outstanding  
 )a  
 LEFT OUTER JOIN Hicl_ProducerMaping PM ON (PM.PPS_PARTY_CODE=CLIENT_CODE)  
 
 GROUP BY  
 a.CLIENT,  
 PLC_DESC,PM.PRODUCER,PDP_DESC, a.docrefno 
 having a.docrefno='2019/04/CBDSPADP00001'
 order by PLC_DESC,PM.PRODUCER;