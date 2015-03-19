<?php
	class data_point
	{
		public $data;
		public $label;
		public function __construct($a_label = NULL, $val = NULL)
		{
			$this->data = $val;
			$this->label = $a_label;
		}
		
	}
?>
