<?php
	class Basic_Form extends Basic_Html_Tag
	{
		const form = 'form';
		const close_tag = '</form>';
		
		const attr_action = 'action';
		const attr_method = 'method';
		
		public $fields = array();
		
		public function __construct()
		{
		}
		
		public function add_field(data_point $to_add)
		{
			$this->fields[] = $data_point_to_add;
		}

		
		
		
	}
?>
