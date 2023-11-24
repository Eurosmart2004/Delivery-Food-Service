delimiter //

create procedure store_order (user_id int, shipper_id int, restaurant_id int, date datetime, delivery_fee float, food_id_count json)
begin
    
    declare i int;
    declare last_order_id int;
    declare length int;
    declare food_id int;
    declare food_count int;

	declare exit handler for sqlexception
    begin
		get diagnostics condition 1 @m = MESSAGE_TEXT;
        select @m as "message";
		resignal;
        rollback;
    end;
    
    start transaction;
    
		insert into orders (user_id, shipper_id, restaurant_id, date, delivery_fee, status) value (user_id, shipper_id, restaurant_id, date, delivery_fee, 'preparing');

        set last_order_id = last_insert_id();
        set length = json_length(food_id_count);
        set i = 0;

        while i < length do
			set food_id = json_extract(food_id_count, concat('$[', i, '].id'));
			set food_count = json_extract(food_id_count, concat('$[', i, '].count'));

			insert into food_order (order_id, food_id, count) value (last_order_id, food_id, food_count);

            set i = i + 1;
        end while;

    commit;
    
    set @row_count = (select count(food_id) from food_order where order_id = last_order_id);
    select last_order_id as last_order_id;

end//

delimiter ;

call store_order (1007, 1234, 3, '2023-11-20 19:00:00', 460.88, '[{"id": 8719, "count": 1}]');
