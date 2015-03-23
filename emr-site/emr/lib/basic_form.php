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
		
		public function this_to_string()
		{
			$str_open_tag = tag_open_bracket .
							form .
							$this->attr_vals_to_str() .
							tag_close_bracket;
			$str_body = "";
			for($i = 0; $i < count($this->fields); $i++)
			{
				$str_body .= ' ' . $this->fields[$i]->label .
							'\n ' . $this->fields[$i]->data .
							'\n ';
			}
			return $str_open_tag . $str_body . close_tag;
		}
		
		public function __toString()
		{
			return this_to_string();
		}
		
		
	}
?>
