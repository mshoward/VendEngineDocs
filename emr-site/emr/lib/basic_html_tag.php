<?php
	class Basic_Html_Tag
	{
		//global attributes
		const attr_accesskey = 'accesskey';
		const attr_class = 'class';
		const attr_contenteditable = 'contenteditable';
		const attr_contextmenu = 'contextmenu';
		
		public $data_star = 'data-'; //TODO
		
		const attr_dir = 'dir';
		const attr_draggable = 'draggable';
		const attr_dropzone = 'dropzone';
		const attr_hidden = 'hidden';
		const attr_id = 'id';
		const attr_lang = 'lang';
		const attr_spellcheck = 'spellcheck';
		const attr_style = 'style';
		const attr_tabindex = 'tabindex';
		const attr_title = 'title';
		const attr_translate = 'translate';
		
		//global events go here
		
		
		//attribute handling goes here
		public $attr_vals = array();
		const equals = '=';
		
		public function __construct()
		{
		}
		public function set_attr($attr, $val)
		{
			$this->attr_vals[$attr] = $val;
		}
		public function rm_attr($attr)
		{
			unset($this->attr_vals[$attr]);
		}
		public function attr_vals_to_str()
		{
			$str = "";
			$attrs = array_keys($this->attr_vals);
			$n = count($attrs);
			for($i = 0; $i < $n; $i++)
			{
				$str .= ' ' . $attrs[$i] . equals . '"' . $this->attr_vals[$attrs[$i]] . '"' . ' ';
			}
			return $str;
		}
	}
?>
