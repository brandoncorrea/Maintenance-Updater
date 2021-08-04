/*
Instructions:
	- Enter the PLUs as 13 digit strings below in a comma separated list,
	- Execute the query
	- Copy the entire Line column and paste this into a text file
	- This text file is your ISP maintenance file

Options:
	- Operation:
		- 1 = Add
		- 2 = Replace
		- 3 = Delete
		- 4 = Add/Update
		- 5 = Clear All
	
	- Line Selection:
		- At the end of the script, Remove the line types
		  that you do not want to see in the results
*/

USE ct2020

/* Initialize Session */
-- Set maintenance operation here
DECLARE @Operation VARCHAR = '4';

SELECT item_id INTO #MaintItems FROM item_tbl
WHERE item_id IN (
-- Enter 13 Digit PLUs Here
{0}
);

/* Select and Format Maintenance Lines */
SELECT * FROM
(
	-- Generate Header Row
	SELECT 
		0 AS SortOrder,
		NULL AS SortOrder2,
		'HD1  ' +
		REPLICATE(' ', 6) +
		LEFT('H/C CORRECTIVE MAINT' + REPLICATE(' ', 50), 50) +
		LEFT('VER02.40H' + REPLICATE(' ', 20), 20) +
		REPLACE(CONVERT(VARCHAR(10), GETDATE(), 120), '-', '') +
		REPLACE(CONVERT(VARCHAR(8), GETDATE(), 108), ':', '') +
		REPLACE(CONVERT(VARCHAR(10), GETDATE(), 120), '-', '') +
		'000001' + 
		'0'
		AS Line

	-- Select from SUPPLIER_TBL
	UNION SELECT DISTINCT 
		1 AS SortOrder,
		NULL AS SortOrder2,
		'SU' +
		RIGHT('0' + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, SU.supplier_number), 8) + 
		RIGHT(REPLICATE('0', 9) + CONVERT(VARCHAR, SU.duns_number), 9) + 
		LEFT(SU.loc_number + REPLICATE(' ', 6), 6) +
		LEFT(SU.name + REPLICATE(' ', 30), 30) +
		LEFT(SU.street_1 + REPLICATE(' ', 35), 35) +
		LEFT(SU.street_2 + REPLICATE(' ', 35), 35) +
		LEFT(SU.city + REPLICATE(' ', 30), 30) +
		LEFT(SU.state + REPLICATE(' ', 2), 2) +
		LEFT(SU.zip_code + REPLICATE(' ', 10), 10) +
		LEFT(SU.rep + REPLICATE(' ', 35), 35) +
		LEFT(SU.phone + REPLICATE(' ', 10), 10) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.dsd), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.ret_only), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.rnd_total), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.rnd_line), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.rnd_each), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.total_accept), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.use_styles), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.total_only), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.total_count), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.cod_flag), 1) + 
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, SU.user_num4_1), 2) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.scan_mode), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.use_containers), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.capture_seals), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.recv_ordered_only), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.accept_exceptions), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.allow_del_charges), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.allow_del_allow), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.allow_ret_charges), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.allow_ret_allow), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.prompt_sup_cost), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.nex_eval), 1) +
		LEFT(SU.count_prompt + REPLICATE(' ', 1), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.allow_add_items), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.dex_auto_print), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.store_can_order), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.consignment), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.gen_852), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.many_inv_per_po), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.gen_invoice_number), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.order_each), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.rnd_order_cases), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.user_bit_1), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.detail), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.warehouse_flag), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.user_num4_2), 2) + 
		CASE WHEN SU.user_bit_4 IS NOT NULL	
			THEN RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.user_bit_4), 1)
			ELSE REPLICATE('~', 1)
		END +
		CASE WHEN SU.user_bit_5 IS NOT NULL	
			THEN RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, SU.user_bit_5), 1)
			ELSE REPLICATE('~', 1)
		END +
		REPLICATE('~', 33)
		AS 'Line'
	FROM supplier_tbl SU 
	JOIN sku_tbl SK 
	ON SK.primary_supplier = SU.supplier_number 
	JOIN item_tbl I 
	ON I.sku = SK.sku 
	WHERE I.item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from ORDGRP_TBL
	UNION SELECT DISTINCT 
		2 AS SortOrder,
		NULL AS SortOrder2,
		'OG' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, O.supplier_number), 8) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, O.order_group), 4) +
		LEFT(O.description + REPLICATE(' ', 20), 20) + 
		REPLICATE('~', 1)
		AS Line
	FROM ordgrp_tbl O
	JOIN supplier_tbl SU 
	ON SU.supplier_number = O.supplier_number
	JOIN sku_tbl SK 
	ON SK.primary_supplier = SU.supplier_number
	JOIN item_tbl I 
	ON I.sku = SK.sku 
	WHERE item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from FAMILY_TBL
	UNION SELECT DISTINCT 
		3 AS SortOrder,
		NULL AS SortOrder2,
		'FA' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' + 
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, F.family_group), 6) +
		LEFT(F.description + REPLICATE(' ', 30), 30)
		+ REPLICATE('~', 1)
		AS Line
	FROM family_tbl F 
	JOIN category_tbl C 
	ON C.family_group = F.family_group
	JOIN sku_tbl S 
	ON S.category_code = C.category_code
	JOIN item_tbl I 
	ON I.sku = S.sku 
	WHERE item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from CATEGORY_TBL
	UNION SELECT DISTINCT 
		4 AS SortOrder,
		NULL AS SortOrder2,
		'CA' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, C.category_code), 8) +
		LEFT(C.description + REPLICATE(' ', 30), 30) +
		CASE WHEN C.family_group IS NOT NULL
			THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, C.family_group), 6)
			ELSE REPLICATE('~', 8)
		END +
		RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR, C.tolerance_amount), 3) +
		RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR, C.tolerance_percent), 3) + 
		LEFT(C.aisle + REPLICATE(' ', 3), 3) +
		LEFT(C.side + REPLICATE(' ', 3), 3) +
		LEFT(C.sect + REPLICATE(' ', 3), 3) +
		LEFT(C.shelf + REPLICATE(' ', 3), 3) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, C.user_num4_1), 4)
		AS 'Line'
	FROM category_tbl C
	JOIN sku_tbl S 
	ON C.category_code = S.category_code
	JOIN item_tbl I 
	ON I.sku = S.sku 
	WHERE item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from SKU_TBL
	UNION SELECT DISTINCT 
		5 AS SortOrder,
		NULL AS SortOrder2,
		'SK' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 13) + RTRIM(S.sku), 13) +
		RIGHT(REPLICATE('0', 13) + RTRIM(S.primary_item_id), 13) +
		LEFT(S.sku_type + REPLICATE('~', 1), 1) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.primary_pack_qty), 4) +
		CASE WHEN S.primary_supplier IS NOT NULL
			THEN RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, S.primary_supplier), 8) 
			ELSE REPLICATE('~', 8)
		END +
		LEFT(S.description + REPLICATE(' ', 30), 30) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.user_bit_5), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.authorized), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.active), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.discontinued), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.user_bit_2), 1) +
		CASE WHEN S.user_date_5 IS NOT NULL
			THEN SUBSTRING(CONVERT(VARCHAR, S.user_date_5, 112), 5, 4)
			ELSE REPLICATE('0', 4)
		END +
		CASE WHEN S.user_date_6 IS NOT NULL
			THEN SUBSTRING(CONVERT(VARCHAR, S.user_date_6, 112), 5, 4)
			ELSE REPLICATE('0', 4)
		END +
		CASE WHEN S.user_date_1 IS NOT NULL
			THEN CONVERT(VARCHAR, S.user_date_1, 112)
			ELSE REPLICATE('0', 8)
		END +
		RIGHT(REPLICATE('0', 1) + S.user_bit_3, 1) +
		CASE WHEN S.user_date_2 IS NOT NULL
			THEN CONVERT(VARCHAR, S.user_date_2, 112)
			ELSE REPLICATE('0', 8)
		END +
		CASE WHEN S.user_date_3 IS NOT NULL
			THEN CONVERT(VARCHAR, S.user_date_3, 112)
			ELSE REPLICATE('0', 8)
		END +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.user_num4_6), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.special_order), 1) +
		REPLICATE('~', 1) + -- Filler
		LEFT(S.status + REPLICATE(' ', 1), 1) +
		CASE WHEN S.category_code IS NOT NULL
			THEN RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, S.category_code), 8)
			ELSE REPLICATE('0', 8)
		END +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.user_num4_1), 4) +
		CASE WHEN S.report_code IS NOT NULL
			THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, S.report_code), 6)
			ELSE REPLICATE('0', 6)
		END +
		CASE WHEN S.cycle_group IS NOT NULL
			THEN RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, S.cycle_group), 8)
			ELSE REPLICATE('0', 8)
		END +
		CASE WHEN S.dept_number IS NOT NULL
			THEN RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.dept_number), 4)
			ELSE REPLICATE('0', 4)
		END +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.store_can_order), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.auto_order), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.disable_sanity_chk), 1) +
		RIGHT(REPLICATE('0', 9) + CONVERT(VARCHAR, S.user_num9_1), 9) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.promo_flag), 1) +
		CASE WHEN S.promo_type IS NOT NULL
			THEN LEFT(S.promo_type + REPLICATE(' ', 2), 2)
			ELSE REPLICATE(' ', 2)
		END +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.reclaim_ok), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.perpetual_flag), 1) +
		LEFT(S.inv_um_code + REPLICATE(' ', 4), 4) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.user_bit_6), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.user_bit_1), 1) +
		LEFT(S.user_string30_1 + REPLICATE(' ', 13), 13) + 
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.user_num4_2), 4) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.user_bit_9), 1) + 
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.user_num4_8), 4) +
		LEFT(S.pack_size + REPLICATE(' ', 8), 8) +
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, S.user_num4_4), 2) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, S.user_bit_12), 1) + 
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, S.user_num4_3), 2) +
		RIGHT(REPLICATE('0', 9) + CONVERT(VARCHAR, CONVERT(INT, S.average_cost * 10000)), 9) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.user_num4_7), 4) +
		CASE WHEN S.user_date_10 IS NOT NULL
			THEN CONVERT(VARCHAR, S.user_date_10, 112)
			ELSE REPLICATE('0', 8)
		END +
		CASE WHEN S.param_group_2 IS NOT NULL
			THEN LEFT(S.param_group_2 + REPLICATE(' ', 9), 9)
			ELSE REPLICATE('~', 9)
		END +
		REPLICATE('~', 2) -- FILLER
		AS 'Line'
	FROM sku_tbl S 
	JOIN item_tbl I ON I.sku = S.sku 
	WHERE I.item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from ITEM_TBL
	UNION SELECT DISTINCT 
		6 AS SortOrder,
		I.link_code AS SortOrder2,
		'IT' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 13) + RTRIM(I.sku), 13) +
		RIGHT(REPLICATE('0', 13) + RTRIM(I.item_id), 13) + 
		LEFT(I.item_type + REPLICATE(' ', 1), 1) +
		RIGHT(REPLICATE('0', 1) + I.pos_item_type, 1) +
		LEFT(I.pos_description + REPLICATE(' ', 18), 18) +
		REPLICATE('~', 2) +
		LEFT(I.um_code + REPLICATE(' ', 2), 2) +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, CONVERT(INT, I.um_factor * 1000)), 8) + 
		LEFT(I.pack_size + REPLICATE(' ', 8), 8) + 
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, I.recv_sell_conv), 4) +
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, CONVERT(INT, I.inv_units * 1000)), 6) +
		RIGHT(REPLICATE('0', 1) + RTRIM(I.price_method), 1) + 
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, CONVERT(INT, I.sell_price * 100)), 6) +
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, I.sell_multiple), 2) +
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, CONVERT(INT, I.bill_price * 100)), 6) +
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, I.bill_multiple), 2) +
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, CONVERT(INT, I.limit_price * 100)), 6) + 
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, I.limit_qty), 2) +
		RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR, I.user_num4_1), 3) +
		RIGHT(REPLICATE('0', 1) + RTRIM(I.user_char_1), 1) +
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, CONVERT(INT, I.user_price_1 * 100)), 6) + 
		REPLICATE('~', 2) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_num4_3), 1) + 
		REPLICATE('~', 1) +
		RIGHT(REPLICATE('0', 7) + CONVERT(VARCHAR, CONVERT(INT, I.user_price_2 * 100)), 7) +
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, I.user_num4_4), 2) +
		CASE WHEN I.mix_match_number IS NOT NULL
			THEN RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, I.mix_match_number), 2)
			ELSE REPLICATE('~', 2)
		END +
		RIGHT(REPLICATE('0', 1) + RTRIM(I.price_reason), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_9), 1) +
		RIGHT(REPLICATE('0', 5) + CONVERT(VARCHAR, I.user_num9_4), 5) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_13), 1) +
		CASE WHEN I.link_code IS NOT NULL
			THEN RIGHT(REPLICATE('0', 13) + RTRIM(I.link_code), 13)
			ELSE REPLICATE(' ', 13)
		END +
		RIGHT(REPLICATE('0', 7) + CONVERT(VARCHAR, CONVERT(INT, I.deposit * 10000)), 7) +
		RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR, I.prev_coupon_family), 3) +
		RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR, I.coupon_family), 3) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.no_coupon), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.elec_coupon), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.coupon_mult), 1) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, CONVERT(INT, I.price_disc_amount * 100)), 4) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, CONVERT(INT, I.price_disc_pct * 100)), 4) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.non_discountable), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.disc_print), 1) +
		RIGHT(REPLICATE('0', 5) + CONVERT(VARCHAR, CONVERT(INT, I.tax_excise * 100)), 5) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.tax_1), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.tax_2), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.tax_3), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.tax_4), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.tax_5), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.tax_6), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.tax_7), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_8), 1) +
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, CONVERT(INT, I.tax_exempt_amount * 100)), 6) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_1), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.food_stamp), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.trading_stamp), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.wic_flag), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_2), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_3), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_7), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.qty_prohibit), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_10), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.not_for_sale), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.restricted_sale), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.visual_verify), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_num4_5), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_num4_6), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_4), 1) +
		CASE WHEN I.user_date_1 IS NOT NULL
			THEN CONVERT(VARCHAR, I.user_date_1, 112)
			ELSE REPLICATE('0', 8)
		END +
		RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR, I.tare_code), 3) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_16), 1) +
		CASE WHEN I.cool_list_id IS NOT NULL
			THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, I.cool_list_id), 6)
			ELSE REPLICATE('~', 6)
		END +
		CASE WHEN I.cool_text_id IS NOT NULL
			THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, I.cool_text_id), 6)
			ELSE REPLICATE('~', 6)
		END +
		CASE WHEN I.cool_class IS NOT NULL
			THEN RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, I.cool_class), 4)
			ELSE REPLICATE('~', 4)
		END + 
		CASE WHEN I.cool_pretext_id IS NOT NULL
			THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR, I.cool_pretext_id), 6)
			ELSE REPLICATE('~', 6)
		END +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.forced_cool), 1) + 
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_19), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_bit_21), 1) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, I.user_num4_7), 1) +
		RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR, I.user_num4_2), 3) +
		REPLICATE('~', 17)
		AS Line
	FROM item_tbl I
	WHERE item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from PACKAGE_TBL
	UNION SELECT DISTINCT
		7 AS SortOrder,
		NULL AS SortOrder2,
		'PK' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 13) + I.sku, 13) +
		RIGHT(REPLICATE('0', 13) + P.pack_id, 13) +
		LEFT(P.pack_type + REPLICATE(' ', 1), 1) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, P.pack_qty), 4) +
		RIGHT(REPLICATE('0', 7) + CONVERT(VARCHAR, CONVERT(INT, P.height * 100)), 7) +
		RIGHT(REPLICATE('0', 7) + CONVERT(VARCHAR, CONVERT(INT, P.width * 100)), 7) +
		RIGHT(REPLICATE('0', 7) + CONVERT(VARCHAR, CONVERT(INT, P.depth * 100)), 7) +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, CONVERT(INT, P.weight * 1000)), 8)
		AS 'Line'
	FROM package_tbl P 
	JOIN item_tbl I 
	ON I.item_id = P.pack_id 
	WHERE pack_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from CASEID_TBL
	UNION SELECT DISTINCT
		8 AS SortOrder,
		NULL AS SortOrder2,
		'CI' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 13) + RTRIM(C.case_id), 13) +
		RIGHT(REPLICATE('0', 13) + RTRIM(C.pack_id), 13) +
		LEFT(C.pack_type + REPLICATE('~', 1), 1) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, C.pack_qty), 4) +
		RIGHT(REPLICATE('0', 13) + RTRIM(I.sku), 13)
		AS 'Line'
	FROM caseid_tbl C 
	JOIN item_tbl I 
	ON I.item_id = C.pack_id 
	WHERE item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from ITEMLOC_TBL
	UNION SELECT DISTINCT 
		9 AS SortOrder,
		NULL AS SortOrder2,
		'IL' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 13) + RTRIM(I.sku), 13) +
		RIGHT(REPLICATE('0', 13) + RTRIM(IL.item_id), 13) +
		RIGHT(REPLICATE('0', 1) + IL.location, 1) +
		LEFT(IL.aisle + REPLICATE(' ', 3), 3) +
		LEFT(IL.side + REPLICATE(' ', 3), 3) +
		LEFT(IL.sect + REPLICATE(' ', 3), 3) +
		LEFT(IL.shelf + REPLICATE(' ', 3), 3) +
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, IL.facings), 2) +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, CONVERT(INT, IL.capacity * 10000)), 8) +
		CASE WHEN IL.form_id_1 IS NOT NULL
			THEN LEFT(IL.form_id_1 + REPLICATE(' ', 10), 10)
			ELSE REPLICATE('~', 10)
		END +
		RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, IL.form_qty_1), 2) +
		RIGHT(REPLICATE('0', 1) + CONVERT(VARCHAR, IL.alt_loc_flag), 1) +
		REPLICATE('~', 20)
		AS 'Line'
	FROM itemloc_tbl IL 
	JOIN item_tbl I 
	ON I.item_id = IL.item_id 
	WHERE I.item_id IN 
	(SELECT item_id FROM #MaintItems)

	-- Select from SUPPACK_TBL
	UNION SELECT DISTINCT
		10 AS SortOrder,
		NULL AS SortOrder2,
		'SP' +
		RIGHT(REPLICATE('0', 1) + @Operation, 1) +
		'  ' +
		RIGHT(REPLICATE('0', 13) + RTRIM(I.sku), 13) +
		RIGHT(REPLICATE('0', 13) + RTRIM(S.pack_id), 13) +
		LEFT(S.pack_type + REPLICATE('~', 1), 1) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.pack_qty), 4) +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, S.supplier_number), 8) +
		RIGHT(REPLICATE('0', 13) + RTRIM(S.order_code), 13) +
		CONVERT(VARCHAR, S.primary_package) + 
		CONVERT(VARCHAR, S.random_weight) +
		CONVERT(VARCHAR, S.order_auth) +
		CONVERT(VARCHAR, S.recv_auth) +
		CASE WHEN S.order_group IS NOT NULL
			THEN RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.order_group), 4)
			ELSE REPLICATE('~', 4)
		END +
		RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, CONVERT(INT, S.cost * 10000)), 8) + 
		CASE WHEN S.allow_group IS NOT NULL
			THEN RIGHT(REPLICATE('0', 8) + CONVERT(VARCHAR, S.allow_group), 8)
			ELSE REPLICATE('~', 8)
		END +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.min_order_qty), 4) +
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.max_order_qty), 4) + 
		RIGHT(REPLICATE('0', 4) + CONVERT(VARCHAR, S.inc_order_qty), 4)
		AS 'Line'
	FROM suppack_tbl S 
	JOIN item_tbl I 
	ON I.item_id = S.pack_id 
	WHERE pack_id IN 
	(SELECT item_id FROM #MaintItems)
) T

-- Remove which Lines you don't want here
WHERE LEFT(Line, 2) IN 
('HD', 'SU', 'OG', 'FA', 'CA', 'SK', 'IT', 'PK', 'CI', 'IL', 'SP')
ORDER BY SortOrder, SortOrder2, Line;

/* Clean up SQL Session */
DROP TABLE #MaintItems;