
//2004-09-20
//µã»÷Ä³¸ö±í±êÌâ£¬½øÐÐÅÅÐò Èç¹û±êÌâÉÏÓÐÍ¼Æ¬¾Í²»ÓÃÅÅÐò

//function window.onload(){
//	tblinit(PowerTable);	
//}


var Main_Tab	= null;
var cur_row_tab	= null;
var cur_col_tab	= null;
var cur_cell	= null;
var Org_con	= "";
var sort_col	= null;

var show_col	= false;
var charMode	= true;

function tblinit(objd){
	cur_row_tab			= null;
	cur_col_tab			= null;
	cur_cell		= null;
	sort_col		= null;
	Main_Tab 		=  objd;
	Main_Tab.onclick	= sortIt;	
	arrowUp = document.createElement("SPAN");
	arrowUp.innerHTML	= "5";
	arrowUp.style.cssText 	= "PADDING-RIGHT: 0px; MARGIN-TOP: -3px; PADDING-LEFT: 0px; FONT-SIZE: 10px; MARGIN-BOTTOM: 2px; PADDING-BOTTOM: 2px; OVERFLOW: hidden; WIDTH: 10px; COLOR: blue; PADDING-TOP: 0px; FONT-FAMILY: webdings; HEIGHT: 11px";

	arrowDown = document.createElement("SPAN");
	arrowDown.innerHTML	= "6";
	arrowDown.style.cssText = "PADDING-RIGHT: 0px; MARGIN-TOP: -3px; PADDING-LEFT: 0px; FONT-SIZE: 10px; MARGIN-BOTTOM: 2px; PADDING-BOTTOM: 2px; OVERFLOW: hidden; WIDTH: 10px; COLOR: blue; PADDING-TOP: 0px; FONT-FAMILY: webdings; HEIGHT: 11px";
}

function get_Element_sort(the_ele,the_tag){
	the_tag = the_tag.toLowerCase();
	if(the_ele.tagName.toLowerCase()==the_tag)
	 return the_ele;
	while(the_ele=the_ele.offsetParent){
	  if(the_ele.tagName.toLowerCase()==the_tag)
		return the_ele;
	}
	return(null);
}

function sortIt(){
	event.cancelBubble=true;
	var the_obj = event.srcElement;
	var i = 0 ,j = 0;
 if (the_obj.tagName  == 'IMG') 
     return;
	if(cur_cell!=null && cur_row_tab!=0){
		cur_cell.children[0].contentEditable = false;
		with(cur_cell.children[0].runtimeStyle){
			borderLeft=borderTop="";
			borderRight=borderBottom="";
			backgroundColor="";
			paddingLeft="";
			textAlign="";
		}
	}
	if(the_obj.tagName.toLowerCase() != "table" && the_obj.tagName.toLowerCase() != "tbody" && the_obj.tagName.toLowerCase() != "tr"){
		var the_td	= get_Element_sort(the_obj,"td");
		if(the_td==null) return;
		var the_tr	= the_td.parentElement;
		var the_table	= get_Element_sort(the_td,"table");
		var i 		= 0;
		cur_row_tab = the_tr.rowIndex;
		cur_col_tab = the_td.cellIndex;
		
		if(cur_row_tab!=0 ){
			
		}else{			
			
			the_td.mode = !the_td.mode;
			if(sort_col!=null){
				with(the_table.rows[0].cells[sort_col])
					removeChild(lastChild);
			}
			with(the_table.rows[0].cells[cur_col_tab])
				appendChild(the_td.mode?arrowUp:arrowDown);
			sort_tab(the_table,cur_col_tab,the_td.mode);
			sort_col=cur_col_tab;
		}
	}
}


var charPYStr = "°¡°¢°£°¤°¥°¦°§°¨°©°ª°«°¬°­°®°¯°°°±°²°³°´°µ°¶°·°¸°¹°º°»°¼°½°¾°¿°À°Á°Â°Ã°Ä°Å°Æ°Ç°È°É°Ê°Ë°Ì°Í°Î°Ï°Ð°Ñ°Ò°Ó°Ô°Õ°Ö°×°Ø°Ù°Ú°Û°Ü°Ý°Þ°ß°à°á°â°ã°ä°å°æ°ç°è°é°ê°ë°ì°í°î°ï°ð°ñ°ò°ó°ô°õ°ö°÷°ø°ù°ú°û°ü°ý°þ±¡±¢±£±¤±¥±¦±§±¨±©±ª±«±¬±­±®±¯±°±±±²±³±´±µ±¶±·±¸±¹±º±»±¼±½±¾±¿±À±Á±Â±Ã±Ä±Å±Æ±Ç±È±É±Ê±Ë±Ì±Í±Î±Ï±Ð±Ñ±Ò±Ó±Ô±Õ±Ö±×±Ø±Ù±Ú±Û±Ü±Ý±Þ±ß±à±á±â±ã±ä±å±æ±ç±è±é±ê±ë±ì±í±î±ï±ð±ñ±ò±ó±ô±õ±ö±÷±ø±ù±ú±û±ü±ý±þ²¡²¢²£²¤²¥²¦²§²¨²©²ª²«²¬²­²®²¯²°²±²²²³²´²µ²¶²·²¸²¹²º²»²¼²½²¾²¿²À²Á²Â²Ã²Ä²Å²Æ²Ç²È²É²Ê²Ë²Ì²Í²Î²Ï²Ð²Ñ²Ò²Ó²Ô²Õ²Ö²×²Ø²Ù²Ú²Û²Ü²Ý²Þ²ß²à²á²â²ã²ä²å²æ²ç²è²é²ê²ë²ì²í²î²ï²ð²ñ²ò²ó²ô²õ²ö²÷²ø²ù²ú²û²ü²ý²þ³¡³¢³£³¤³¥³¦³§³¨³©³ª³«³¬³­³®³¯³°³±³²³³³´³µ³¶³·³¸³¹³º³»³¼³½³¾³¿³À³Á³Â³Ã³Ä³Å³Æ³Ç³È³É³Ê³Ë³Ì³Í³Î³Ï³Ð³Ñ³Ò³Ó³Ô³Õ³Ö³×³Ø³Ù³Ú³Û³Ü³Ý³Þ³ß³à³á³â³ã³ä³å³æ³ç³è³é³ê³ë³ì³í³î³ï³ð³ñ³ò³ó³ô³õ³ö³÷³ø³ù³ú³û³ü³ý³þ´¡´¢´£´¤´¥´¦´§´¨´©´ª´«´¬´­´®´¯´°´±´²´³´´´µ´¶´·´¸´¹´º´»´¼´½´¾´¿´À´Á´Â´Ã´Ä´Å´Æ´Ç´È´É´Ê´Ë´Ì´Í´Î´Ï´Ð´Ñ´Ò´Ó´Ô´Õ´Ö´×´Ø´Ù´Ú´Û´Ü´Ý´Þ´ß´à´á´â´ã´ä´å´æ´ç´è´é´ê´ë´ì´í´î´ï´ð´ñ´ò´ó´ô´õ´ö´÷´ø´ù´ú´û´ü´ý´þµ¡µ¢µ£µ¤µ¥µ¦µ§µ¨µ©µªµ«µ¬µ­µ®µ¯µ°µ±µ²µ³µ´µµµ¶µ·µ¸µ¹µºµ»µ¼µ½µ¾µ¿µÀµÁµÂµÃµÄµÅµÆµÇµÈµÉµÊµËµÌµÍµÎµÏµÐµÑµÒµÓµÔµÕµÖµ×µØµÙµÚµÛµÜµÝµÞµßµàµáµâµãµäµåµæµçµèµéµêµëµìµíµîµïµðµñµòµóµôµõµöµ÷µøµùµúµûµüµýµþ¶¡¶¢¶£¶¤¶¥¶¦¶§¶¨¶©¶ª¶«¶¬¶­¶®¶¯¶°¶±¶²¶³¶´¶µ¶¶¶·¶¸¶¹¶º¶»¶¼¶½¶¾¶¿¶À¶Á¶Â¶Ã¶Ä¶Å¶Æ¶Ç¶È¶É¶Ê¶Ë¶Ì¶Í¶Î¶Ï¶Ð¶Ñ¶Ò¶Ó¶Ô¶Õ¶Ö¶×¶Ø¶Ù¶Ú¶Û¶Ü¶Ý¶Þ¶ß¶à¶á¶â¶ã¶ä¶å¶æ¶ç¶è¶é¶ê¶ë¶ì¶í¶î¶ï¶ð¶ñ¶ò¶ó¶ô¶õ¶ö¶÷¶ø¶ù¶ú¶û¶ü¶ý¶þ·¡·¢·£·¤·¥·¦·§·¨·©·ª·«·¬·­·®·¯·°·±·²·³·´·µ·¶···¸·¹·º·»·¼·½·¾·¿·À·Á·Â·Ã·Ä·Å·Æ·Ç·È·É·Ê·Ë·Ì·Í·Î·Ï·Ð·Ñ·Ò·Ó·Ô·Õ·Ö·×·Ø·Ù·Ú·Û·Ü·Ý·Þ·ß·à·á·â·ã·ä·å·æ·ç·è·é·ê·ë·ì·í·î·ï·ð·ñ·ò·ó·ô·õ·ö·÷·ø·ù·ú·û·ü·ý·þ¸¡¸¢¸£¸¤¸¥¸¦¸§¸¨¸©¸ª¸«¸¬¸­¸®¸¯¸°¸±¸²¸³¸´¸µ¸¶¸·¸¸¸¹¸º¸»¸¼¸½¸¾¸¿¸À¸Á¸Â¸Ã¸Ä¸Å¸Æ¸Ç¸È¸É¸Ê¸Ë¸Ì¸Í¸Î¸Ï¸Ð¸Ñ¸Ò¸Ó¸Ô¸Õ¸Ö¸×¸Ø¸Ù¸Ú¸Û¸Ü¸Ý¸Þ¸ß¸à¸á¸â¸ã¸ä¸å¸æ¸ç¸è¸é¸ê¸ë¸ì¸í¸î¸ï¸ð¸ñ¸ò¸ó¸ô¸õ¸ö¸÷¸ø¸ù¸ú¸û¸ü¸ý¸þ¹¡¹¢¹£¹¤¹¥¹¦¹§¹¨¹©¹ª¹«¹¬¹­¹®¹¯¹°¹±¹²¹³¹´¹µ¹¶¹·¹¸¹¹¹º¹»¹¼¹½¹¾¹¿¹À¹Á¹Â¹Ã¹Ä¹Å¹Æ¹Ç¹È¹É¹Ê¹Ë¹Ì¹Í¹Î¹Ï¹Ð¹Ñ¹Ò¹Ó¹Ô¹Õ¹Ö¹×¹Ø¹Ù¹Ú¹Û¹Ü¹Ý¹Þ¹ß¹à¹á¹â¹ã¹ä¹å¹æ¹ç¹è¹é¹ê¹ë¹ì¹í¹î¹ï¹ð¹ñ¹ò¹ó¹ô¹õ¹ö¹÷¹ø¹ù¹ú¹û¹ü¹ý¹þº¡º¢º£º¤º¥º¦º§º¨º©ºªº«º¬º­º®º¯º°º±º²º³º´ºµº¶º·º¸º¹ººº»º¼º½º¾º¿ºÀºÁºÂºÃºÄºÅºÆºÇºÈºÉºÊºËºÌºÍºÎºÏºÐºÑºÒºÓºÔºÕºÖº×ºØºÙºÚºÛºÜºÝºÞºßºàºáºâºãºäºåºæºçºèºéºêºëºìºíºîºïºðºñºòºóºôºõºöº÷ºøºùºúºûºüºýºþ»¡»¢»£»¤»¥»¦»§»¨»©»ª»«»¬»­»®»¯»°»±»²»³»´»µ»¶»·»¸»¹»º»»»¼»½»¾»¿»À»Á»Â»Ã»Ä»Å»Æ»Ç»È»É»Ê»Ë»Ì»Í»Î»Ï»Ð»Ñ»Ò»Ó»Ô»Õ»Ö»×»Ø»Ù»Ú»Û»Ü»Ý»Þ»ß»à»á»â»ã»ä»å»æ»ç»è»é»ê»ë»ì»í»î»ï»ð»ñ»ò»ó»ô»õ»ö»÷»ø»ù»ú»û»ü»ý»þ¼¡¼¢¼£¼¤¼¥¼¦¼§¼¨¼©¼ª¼«¼¬¼­¼®¼¯¼°¼±¼²¼³¼´¼µ¼¶¼·¼¸¼¹¼º¼»¼¼¼½¼¾¼¿¼À¼Á¼Â¼Ã¼Ä¼Å¼Æ¼Ç¼È¼É¼Ê¼Ë¼Ì¼Í¼Î¼Ï¼Ð¼Ñ¼Ò¼Ó¼Ô¼Õ¼Ö¼×¼Ø¼Ù¼Ú¼Û¼Ü¼Ý¼Þ¼ß¼à¼á¼â¼ã¼ä¼å¼æ¼ç¼è¼é¼ê¼ë¼ì¼í¼î¼ï¼ð¼ñ¼ò¼ó¼ô¼õ¼ö¼÷¼ø¼ù¼ú¼û¼ü¼ý¼þ½¡½¢½£½¤½¥½¦½§½¨½©½ª½«½¬½­½®½¯½°½±½²½³½´½µ½¶½·½¸½¹½º½»½¼½½½¾½¿½À½Á½Â½Ã½Ä½Å½Æ½Ç½È½É½Ê½Ë½Ì½Í½Î½Ï½Ð½Ñ½Ò½Ó½Ô½Õ½Ö½×½Ø½Ù½Ú¾¥¾¦¾§¾¨¾©¾ª¾«¾¬¾­¾®¾¯¾°¾±¾²¾³¾´¾µ¾¶¾·¾¸¾¹¾º¾»¾¼¾½¾¾¾¿¾À¾Á¾Â¾Ã¾Ä¾Å¾Æ¾Ç¾È¾É¾Ê¾Ë¾Ì¾Í¾Î¾Ï¾Ð¾Ñ¾Ò¾Ó¾Ô¾Õ¾Ö¾×¾Ø¾Ù¾Ú¾Û¾Ü¾Ý¾Þ¾ß¾à¾á¾â¾ã¾ä¾å¾æ¾ç¾è¾é¾ê¾ë¾ì¾í¾î¾ï¾ð¾ñ¾ò¾ó¾ô½Û½Ü½Ý½Þ½ß½à½á½â½ã½ä½å½æ½ç½è½é½ê½ë½ì½í½î½ï½ð½ñ½ò½ó½ô½õ½ö½÷½ø½ù½ú½û½ü½ý½þ¾¡¾¢¾£¾¤¾õ¾ö¾÷¾ø¾ù¾ú¾û¾ü¾ý¾þ¿¡¿¢¿£¿¤¿¥¿¦¿§¿¨¿©¿ª¿«¿¬¿­¿®¿¯¿°¿±¿²¿³¿´¿µ¿¶¿·¿¸¿¹¿º¿»¿¼¿½¿¾¿¿¿À¿Á¿Â¿Ã¿Ä¿Å¿Æ¿Ç¿È¿É¿Ê¿Ë¿Ì¿Í¿Î¿Ï¿Ð¿Ñ¿Ò¿Ó¿Ô¿Õ¿Ö¿×¿Ø¿Ù¿Ú¿Û¿Ü¿Ý¿Þ¿ß¿à¿á¿â¿ã¿ä¿å¿æ¿ç¿è¿é¿ê¿ë¿ì¿í¿î¿ï¿ð¿ñ¿ò¿ó¿ô¿õ¿ö¿÷¿ø¿ù¿ú¿û¿ü¿ý¿þÀ¡À¢À£À¤À¥À¦À§À¨À©ÀªÀ«À¬À­À®À¯À°À±À²À³À´ÀµÀ¶À·À¸À¹ÀºÀ»À¼À½À¾À¿ÀÀÀÁÀÂÀÃÀÄÀÅÀÆÀÇÀÈÀÉÀÊÀËÀÌÀÍÀÎÀÏÀÐÀÑÀÒÀÓÀÔÀÕÀÖÀ×ÀØÀÙÀÚÀÛÀÜÀÝÀÞÀßÀàÀáÀâÀãÀäÀåÀæÀçÀèÀéÀêÀëÀìÀíÀîÀïÀðÀñÀòÀóÀôÀõÀöÀ÷ÀøÀùÀúÀûÀüÀýÀþÁ¡Á¢Á£Á¤Á¥Á¦Á§Á¨Á©ÁªÁ«Á¬Á­Á®Á¯Á°Á±Á²Á³Á´ÁµÁ¶Á·Á¸Á¹ÁºÁ»Á¼Á½Á¾Á¿ÁÀÁÁÁÂÁÃÁÄÁÅÁÆÁÇÁÈÁÉÁÊÁËÁÌÁÍÁÎÁÏÁÐÁÑÁÒÁÓÁÔÁÕÁÖÁ×ÁØÁÙÁÚÁÛÁÜÁÝÁÞÁßÁàÁáÁâÁãÁäÁåÁæÁçÁèÁéÁêÁëÁìÁíÁîÁïÁðÁñÁòÁóÁôÁõÁöÁ÷ÁøÁùÁúÁûÁüÁýÁþÂ¡Â¢Â£Â¤Â¥Â¦Â§Â¨Â©ÂªÂ«Â¬Â­Â®Â¯Â°Â±Â²Â³Â´ÂµÂ¶Â·Â¸Â¹ÂºÂ»Â¼Â½Â¾Â¿ÂÀÂÁÂÂÂÃÂÄÂÅÂÆÂÇÂÈÂÉÂÊÂËÂÌÂÍÂÎÂÏÂÐÂÑÂÒÂÓÂÔÂÕÂÖÂ×ÂØÂÙÂÚÂÛÂÜÂÝÂÞÂßÂàÂáÂâÂãÂäÂåÂæÂçÂèÂéÂêÂëÂìÂíÂîÂïÂðÂñÂòÂóÂôÂõÂöÂ÷ÂøÂùÂúÂûÂüÂýÂþÃ¡Ã¢Ã£Ã¤Ã¥Ã¦Ã§Ã¨Ã©ÃªÃ«Ã¬Ã­Ã®Ã¯Ã°Ã±Ã²Ã³Ã´ÃµÃ¶Ã·Ã¸Ã¹ÃºÃ»Ã¼Ã½Ã¾Ã¿ÃÀÃÁÃÂÃÃÃÄÃÅÃÆÃÇÃÈÃÉÃÊÃËÃÌÃÍÃÎÃÏÃÐÃÑÃÒÃÓÃÔÃÕÃÖÃ×ÃØÃÙÃÚÃÛÃÜÃÝÃÞÃßÃàÃáÃâÃãÃäÃåÃæÃçÃèÃéÃêÃëÃìÃíÃîÃïÃðÃñÃòÃóÃôÃõÃöÃ÷ÃøÃùÃúÃûÃüÃýÃþÄ¡Ä¢Ä£Ä¤Ä¥Ä¦Ä§Ä¨Ä©ÄªÄ«Ä¬Ä­Ä®Ä¯Ä°Ä±Ä²Ä³Ä´ÄµÄ¶Ä·Ä¸Ä¹ÄºÄ»Ä¼Ä½Ä¾Ä¿ÄÀÄÁÄÂÄÃÄÄÄÅÄÆÄÇÄÈÄÉÄÊÄËÄÌÄÍÄÎÄÏÄÐÄÑÄÒÄÓÄÔÄÕÄÖÄ×ÄØÄÙÄÚÄÛÄÜÄÝÄÞÄßÄàÄáÄâÄãÄäÄåÄæÄçÄèÄéÄêÄëÄìÄíÄîÄïÄðÄñÄòÄóÄôÄõÄöÄ÷ÄøÄùÄúÄûÄüÄýÄþÅ¡Å¢Å£Å¤Å¥Å¦Å§Å¨Å©ÅªÅ«Å¬Å­Å®Å¯Å°Å±Å²Å³Å´ÅµÅ¶Å·Å¸Å¹ÅºÅ»Å¼Å½Å¾Å¿ÅÀÅÁÅÂÅÃÅÄÅÅÅÆÅÇÅÈÅÉÅÊÅËÅÌÅÍÅÎÅÏÅÐÅÑÅÒÅÓÅÔÅÕÅÖÅ×ÅØÅÙÅÚÅÛÅÜÅÝÅÞÅßÅàÅáÅâÅãÅäÅåÅæÅçÅèÅéÅêÅëÅìÅíÅîÅïÅðÅñÅòÅóÅôÅõÅöÅ÷ÅøÅùÅúÅûÅüÅýÅþÆ¡Æ¢Æ£Æ¤Æ¥Æ¦Æ§Æ¨Æ©ÆªÆ«Æ¬Æ­Æ®Æ¯Æ°Æ±Æ²Æ³Æ´ÆµÆ¶Æ·Æ¸Æ¹ÆºÆ»Æ¼Æ½Æ¾Æ¿ÆÀÆÁÆÂÆÃÆÄÆÅÆÆÆÇÆÈÆÉÆÊÆËÆÌÆÍÆÎÆÏÆÐÆÑÆÒÆÓÆÔÆÕÆÖÆ×ÆØÆÙÆÚÆÛÆÜÆÝÆÞÆßÆàÆáÆâÆãÆäÆåÆæÆçÆèÆéÆêÆëÆìÆíÆîÆïÆðÆñÆòÆóÆôÆõÆöÆ÷ÆøÆùÆúÆûÆüÆýÆþÇ¢Ç£Ç¤Ç¥Ç¦Ç§Ç¨Ç©ÇªÇ«Ç¬Ç­Ç®Ç¯Ç°Ç±Ç²Ç³Ç´ÇµÇ¶Ç·Ç¸Ç¹ÇºÇ»Ç¼Ç½Ç¾Ç¿ÇÀÇÁÇÂÇÃÇÄÇÅÇÆÇÇÇÈÇÉÇÊÇËÇÌÇÍÇÎÇÏÇÐÇÑÇÒÇÓÇÔÇÕÇÖÇ×ÇØÇÙÇÚÇÛÇÜÇÝÇÞÇßÇàÇáÇâÇãÇäÇåÇæÇçÇèÇéÇêÇëÇìÇíÇîÇïÇðÇñÇòÇóÇôÇõÇöÇ÷ÇøÇùÇúÇûÇüÇýÇþÈ¡È¢È£È¤È¥È¦È§È¨È©ÈªÈ«È¬È­È®È¯È°È±È²È³È´ÈµÈ¶È·È¸È¹ÈºÈ»È¼È½È¾È¿ÈÀÈÁÈÂÈÃÈÄÈÅÈÆÈÇÈÈÈÉÈÊÈËÈÌÈÍÈÎÈÏÈÐÈÑÈÒÈÓÈÔÈÕÈÖÈ×ÈØÈÙÈÚÈÛÈÜÈÝÈÞÈßÈàÈáÈâÈãÈäÈåÈæÈçÈèÈéÈêÈëÈìÈíÈîÈïÈðÈñÈòÈóÈôÈõÈöÈ÷ÈøÈùÈúÈûÈüÈýÈþÉ¡É¢É£É¤É¥É¦É§É¨É©ÉªÉ«É¬É­É®É¯É°É±É²É³É´ÉµÉ¶É·É¸É¹ÉºÉ»É¼É½É¾É¿ÉÀÉÁÉÂÉÃÉÄÉÅÉÆÉÇÉÈÉÉÉÊÉËÉÌÉÍÉÎÉÏÉÐÉÑÉÒÉÓÉÔÉÕÉÖÉ×ÉØÉÙÉÚÉÛÉÜÉÝÉÞÉßÉàÉáÉâÉãÉäÉåÉæÉçÉèÉéÉêÉëÉìÉíÉîÉïÉðÉñÉòÉóÉôÉõÉöÉ÷ÉøÉùÉúÉûÉüÉýÉþÊ¡Ê¢Ê£Ê¤Ê¥Ê¦Ê§Ê¨Ê©ÊªÊ«Ê¬Ê­Ê®Ê¯Ê°Ê±Ê²Ê³Ê´ÊµÊ¶Ê·Ê¸Ê¹ÊºÊ»Ê¼Ê½Ê¾Ê¿ÊÀÊÁÊÂÊÃÊÄÊÅÊÆÊÇÊÈÊÉÊÊÊËÊÌÊÍÊÎÊÏÊÐÊÑÊÒÊÓÊÔÊÕÊÖÊ×ÊØÊÙÊÚÊÛÊÜÊÝÊÞÊßÊàÊáÊâÊãÊäÊåÊæÊçÊèÊéÊêÊëÊìÊíÊîÊïÊðÊñÊòÊóÊôÊõÊöÊ÷ÊøÊùÊúÊûÊüÊýÊþË¡Ë¢Ë£Ë¤Ë¥Ë¦Ë§Ë¨Ë©ËªË«Ë¬Ë­Ë®Ë¯Ë°Ë±Ë²Ë³Ë´ËµË¶Ë·Ë¸Ë¹ËºË»Ë¼Ë½Ë¾Ë¿ËÀËÁËÂËÃËÄËÅËÆËÇËÈËÉËÊËËËÌËÍËÎËÏËÐËÑËÒËÓËÔËÕËÖË×ËØËÙËÚËÛËÜËÝËÞËßËàËáËâËãËäËåËæËçËèËéËêËëËìËíËîËïËðËñËòËóËôËõËöË÷ËøËùËúËûËüËýËþÌ¡Ì¢Ì£Ì¤Ì¥Ì¦Ì§Ì¨Ì©ÌªÌ«Ì¬Ì­Ì®Ì¯Ì°Ì±Ì²Ì³Ì´ÌµÌ¶Ì·Ì¸Ì¹ÌºÌ»Ì¼Ì½Ì¾Ì¿ÌÀÌÁÌÂÌÃÌÄÌÅÌÆÌÇÌÈÌÉÌÊÌËÌÌÌÍÌÎÌÏÌÐÌÑÌÒÌÓÌÔÌÕÌÖÌ×ÌØÌÙÌÚÌÛÌÜÌÝÌÞÌßÌàÌáÌâÌãÌäÌåÌæÌçÌèÌéÌêÌëÌìÌíÌîÌïÌðÌñÌòÌóÌôÌõÌöÌ÷ÌøÌùÌúÌûÌüÌýÌþÍ¡Í¢Í£Í¤Í¥Í¦Í§Í¨Í©ÍªÍ«Í¬Í­Í®Í¯Í°Í±Í²Í³Í´ÍµÍ¶Í·Í¸Í¹ÍºÍ»Í¼Í½Í¾Í¿ÍÀÍÁÍÂÍÃÍÄÍÅÍÆÍÇÍÈÍÉÍÊÍËÍÌÍÍÍÎÍÏÍÐÍÑÍÒÍÓÍÔÍÕÍÖÍ×ÍØÍÙÍÚÍÛÍÜÍÝÍÞÍßÍàÍáÍâÍãÍäÍåÍæÍçÍèÍéÍêÍëÍìÍíÍîÍïÍðÍñÍòÍóÍôÍõÍöÍ÷ÍøÍùÍúÍûÍüÍýÍþÎ¡Î¢Î£Î¤Î¥Î¦Î§Î¨Î©ÎªÎ«Î¬Î­Î®Î¯Î°Î±Î²Î³Î´ÎµÎ¶Î·Î¸Î¹ÎºÎ»Î¼Î½Î¾Î¿ÎÀÎÁÎÂÎÃÎÄÎÅÎÆÎÇÎÈÎÉÎÊÎËÎÌÎÍÎÎÎÏÎÐÎÑÎÒÎÓÎÔÎÕÎÖÎ×ÎØÎÙÎÚÎÛÎÜÎÝÎÞÎßÎàÎáÎâÎãÎäÎåÎæÎçÎèÎéÎêÎëÎìÎíÎîÎïÎðÎñÎòÎóÎôÎõÎöÎ÷ÎøÎùÎúÎûÎüÎýÎþÏ¡Ï¢Ï£Ï¤Ï¥Ï¦Ï§Ï¨Ï©ÏªÏ«Ï¬Ï­Ï®Ï¯Ï°Ï±Ï²Ï³Ï´ÏµÏ¶Ï·Ï¸Ï¹ÏºÏ»Ï¼Ï½Ï¾Ï¿ÏÀÏÁÏÂÏÃÏÄÏÅÏÆÏÇÏÈÏÉÏÊÏËÏÌÏÍÏÎÏÏÏÐÏÑÏÒÏÓÏÔÏÕÏÖÏ×ÏØÏÙÏÚÏÛÏÜÏÝÏÞÏßÏàÏáÏâÏãÏäÏåÏæÏçÏèÏéÏêÏëÏìÏíÏîÏïÏðÏñÏòÏóÏôÏõÏöÏ÷ÏøÏùÏúÏûÏüÏýÏþÐ¡Ð¢Ð£Ð¤Ð¥Ð¦Ð§Ð¨Ð©ÐªÐ«Ð¬Ð­Ð®Ð¯Ð°Ð±Ð²Ð³Ð´ÐµÐ¶Ð·Ð¸Ð¹ÐºÐ»Ð¼Ð½Ð¾Ð¿ÐÀÐÁÐÂÐÃÐÄÐÅÐÆÐÇÐÈÐÉÐÊÐËÐÌÐÍÐÎÐÏÐÐÐÑÐÒÐÓÐÔÐÕÐÖÐ×ÐØÐÙÐÚÐÛÐÜÐÝÐÞÐßÐàÐáÐâÐãÐäÐåÐæÐçÐèÐéÐêÐëÐìÐíÐîÐïÐðÐñÐòÐóÐôÐõÐöÐ÷ÐøÐùÐúÐûÐüÐýÐþÑ¡Ñ¢Ñ£Ñ¤Ñ¥Ñ¦Ñ§Ñ¨Ñ©ÑªÑ«Ñ¬Ñ­Ñ®Ñ¯Ñ°Ñ±Ñ²Ñ³Ñ´ÑµÑ¶Ñ·Ñ¸Ñ¹ÑºÑ»Ñ¼Ñ½Ñ¾Ñ¿ÑÀÑÁÑÂÑÃÑÄÑÅÑÆÑÇÑÈÑÉÑÊÑËÑÌÑÍÑÎÑÏÑÐÑÑÑÒÑÓÑÔÑÕÑÖÑ×ÑØÑÙÑÚÑÛÑÜÑÝÑÞÑßÑàÑáÑâÑãÑäÑåÑæÑçÑèÑéÑêÑëÑìÑíÑîÑïÑðÑñÑòÑóÑôÑõÑöÑ÷ÑøÑùÑúÑûÑüÑýÑþÒ¡Ò¢Ò£Ò¤Ò¥Ò¦Ò§Ò¨Ò©ÒªÒ«Ò¬Ò­Ò®Ò¯Ò°Ò±Ò²Ò³Ò´ÒµÒ¶Ò·Ò¸Ò¹ÒºÒ»Ò¼Ò½Ò¾Ò¿ÒÀÒÁÒÂÒÃÒÄÒÅÒÆÒÇÒÈÒÉÒÊÒËÒÌÒÍÒÎÒÏÒÐÒÑÒÒÒÓÒÔÒÕÒÖÒ×ÒØÒÙÒÚÒÛÒÜÒÝÒÞÒßÒàÒáÒâÒãÒäÒåÒæÒçÒèÒéÒêÒëÒìÒíÒîÒïÒðÒñÒòÒóÒôÒõÒöÒ÷ÒøÒùÒúÒûÒüÒýÒþÓ¡Ó¢Ó£Ó¤Ó¥Ó¦Ó§Ó¨Ó©ÓªÓ«Ó¬Ó­Ó®Ó¯Ó°Ó±Ó²Ó³Ó´ÓµÓ¶Ó·Ó¸Ó¹ÓºÓ»Ó¼Ó½Ó¾Ó¿ÓÀÓÁÓÂÓÃÓÄÓÅÓÆÓÇÓÈÓÉÓÊÓËÓÌÓÍÓÎÓÏÓÐÓÑÓÒÓÓÓÔÓÕÓÖÓ×ÓØÓÙÓÚÓÛÓÜÓÝÓÞÓßÓàÓáÓâÓãÓäÓåÓæÓçÓèÓéÓêÓëÓìÓíÓîÓïÓðÓñÓòÓóÓôÓõÓöÓ÷ÓøÓùÓúÓûÓüÓýÓþÔ¡Ô¢Ô£Ô¤Ô¥Ô¦Ô§Ô¨Ô©ÔªÔ«Ô¬Ô­Ô®Ô¯Ô°Ô±Ô²Ô³Ô´ÔµÔ¶Ô·Ô¸Ô¹ÔºÔ»Ô¼Ô½Ô¾Ô¿ÔÀÔÁÔÂÔÃÔÄÔÅÔÆÔÇÔÈÔÉÔÊÔËÔÌÔÍÔÎÔÏÔÐÔÑÔÒÔÓÔÔÔÕÔÖÔ×ÔØÔÙÔÚÔÛÔÜÔÝÔÞÔßÔàÔáÔâÔãÔäÔåÔæÔçÔèÔéÔêÔëÔìÔíÔîÔïÔðÔñÔòÔóÔôÔõÔöÔ÷ÔøÔùÔúÔûÔüÔýÔþÕ¡Õ¢Õ£Õ¤Õ¥Õ¦Õ§Õ¨Õ©ÕªÕ«Õ¬Õ­Õ®Õ¯Õ°Õ±Õ²Õ³Õ´ÕµÕ¶Õ·Õ¸Õ¹ÕºÕ»Õ¼Õ½Õ¾Õ¿ÕÀÕÁÕÂÕÃÕÄÕÅÕÆÕÇÕÈÕÉÕÊÕËÕÌÕÍÕÎÕÏÕÐÕÑÕÒÕÓÕÔÕÕÕÖÕ×ÕØÕÙÕÚÕÛÕÜÕÝÕÞÕßÕàÕáÕâÕãÕäÕåÕæÕçÕèÕéÕêÕëÕìÕíÕîÕïÕðÕñÕòÕóÕôÕõÕöÕ÷ÕøÕùÕúÕûÕüÕýÕþÖ¡Ö¢Ö£Ö¤Ö¥Ö¦Ö§Ö¨Ö©ÖªÖ«Ö¬Ö­Ö®Ö¯Ö°Ö±Ö²Ö³Ö´ÖµÖ¶Ö·Ö¸Ö¹ÖºÖ»Ö¼Ö½Ö¾Ö¿ÖÀÖÁÖÂÖÃÖÄÖÅÖÆÖÇÖÈÖÉÖÊÖËÖÌÖÍÖÎÖÏÖÐÖÑÖÒÖÓÖÔÖÕÖÖÖ×ÖØÖÙÖÚÖÛÖÜÖÝÖÞÖßÖàÖáÖâÖãÖäÖåÖæÖçÖèÖéÖêÖëÖìÖíÖîÖïÖðÖñÖòÖóÖôÖõÖöÖ÷ÖøÖùÖúÖûÖüÖýÖþ×¡×¢×£×¤×¥×¦×§×¨×©×ª×«×¬×­×®×¯×°×±×²×³×´×µ×¶×·×¸×¹×º×»×¼×½×¾×¿×À×Á×Â×Ã×Ä×Å×Æ×Ç×È×É×Ê×Ë×Ì×Í×Î×Ï×Ð×Ñ×Ò×Ó×Ô×Õ×Ö×××Ø×Ù×Ú×Û×Ü×Ý×Þ×ß×à×á×â×ã×ä×å×æ×ç×è×é×ê×ë×ì×í×î×ï×ð×ñ×ò×ó×ô×õ×ö×÷×ø×ù";
var charBHStr = "Ò»ÒÒ¶¡ÆßÄË¾ÅÁË¶þÈË¶ùÈë°Ë¼¸µ¶µóÁ¦Ê®²·³§ÓÖÍòÕÉÈýÉÏÏÂ¸öÑ¾Íè¾ÃÃ´ÒåÆòÒ²Ï°ÏçÓÚ¿÷ÍöÒÚ·²ÈÐÉ×Ç§ÎÀ²æ¿ÚÍÁÊ¿Ï¦´óÅ®×Ó´çÐ¡Ê¬É½´¨¹¤¼ºÒÑËÈ½í¸É¹ã¹­²ÅÃÅ·ÉÂí²»Óë³ó×¨ÖÐ·áµ¤ÎªÖ®ÎÚÊéÓèÔÆ»¥Îå¾®¿ºÊ²ÈÊ½öÆÍ³ð½ñ½éÈÔ´ÓÂØ²ÖÔÊÔª¹«ÁùÄÚ¸ÔÈß·ïÐ×·ÖÇÐÈ°°ì¹´ÎðÔÈ»¯Æ¥ÇøÉýÎç±å¶òÌüÀú¼°ÓÑË«·´ÈÉÌìÌ«·ò¿×ÉÙÓÈÒü³ßÍÍ°Í±Ò»Ã¿ªÒýÐÄÒä¸ê»§ÊÖÔúÖ§ÎÄ¶·½ï·½ÎÞÈÕÔ»ÔÂÄ¾Ç·Ö¹´õÎã±ÈÃ«ÊÏÆøË®»ð×¦¸¸Æ¬ÑÀÅ£È®ÍõÍßÒÕ¼û¼Æ¶©¸¼ÈÏ¼¥±´³µµË³¤¶ÓÎ¤·çÇÒÊÀÇð±ûÒµ´Ô¶«Ë¿Ö÷Õ§ºõ·¦ÀÖ×ÐÊËËûÕÌ¸¶ÏÉÇª´úÁîÒÔÒÇÃÇÐÖÀ¼È½²áÐ´¶¬·ëÍ¹°¼³ö»÷¿¯¹¦¼ÓÎñ°ü´Ò±±ÔÑ»Ü°ëÕ¼¿¨Â¬Ã®À÷È¥·¢¹Å¾äÁíÖ»½ÐÕÙ°È¶£¿ÉÌ¨Ê·ÓÒÒ¶ºÅË¾Ì¾µðÇôËÄÊ¥´¦ÍâÑëº»Ê§Í·Å«ÄÌÔÐÄþËü¶Ô¶ûÄá×óÇÉ¾ÞÊÐ²¼Ë§Æ½Ó×¸¥ºë¹é±ØÎìÆË°Ç´òÈÓ³âµ©¾ÉÎ´Ä©±¾ÔýÊõÕýÄ¸ÃñÓÀÍ¡Ö­»ãººÃð·¸ÐþÓñ¹Ï¸ÊÉúÓÃË¦ÌïÓÉ¼×Éêµç°×Æ¤ÃóÄ¿Ã¬Ê¸Ê¯Ê¾ÀñºÌÑ¨Á¢¾À°¬½ÚÌÖÈÃÆýÑµÒéÑ¶¼ÇÔþ±ßÁÉÉÁ¼¢Ô¦ÄñÁú¶ªÆ¹ÅÒÇÇÂòÕùÑÇ½»º¥Òà²úÑöÖÙ¼þ¼ÛÈÎ·Ý·ÂÆóÒÁÎé¼¿·ü·¥ÐÝÖÚÓÅ»ï»áÉ¡Î°´«ÉËÂ×Î±³äÕ×ÏÈ¹âÈ«¹²¹ØÐËÔÙ¾üÅ©±ù³å¾öÐÌ»®ÁÐÁõÔò¸Õ´´ÁÓ¶¯ÐÙ½³¿ï»ªÐ­Ó¡Î£Ñ¹ÑáÓõ³Ô¸÷ºÏ¼ªµõÍ¬ÃûºóÀôÍÂÏòÏÅÂÀÂð»ØÒòÍÅÔÚ¹çµØ³¡»ø×³¶àÒÄ¿ä¼Ð¶á¼éËýºÃÈçÍý×±¸¾Âè×Ö´æËïÕ¬ÓîÊØ°²ËÂÑ°µ¼¼â³¾Ò¢¾¡ÒÙÓìËêÆñÖÝÑ²¹®·«Ê¦Äê²¢×¯ÇìÑÓÍ¢ÒìÊ½³Úµ±Ã¦ÐçÊùÈÖÏ·³ÉÍÐ¿¸¿ÛÇ¤Ö´À©É¨ÑïÊÕÖ¼ÔçÑ®ÐñÇúÒ·ÓÐÖìÆÓ¶ä»úÐàÉ±ÔÓÈ¨´Î»¶´ËËÀ±ÏÄÊÏ«ÉÇº¹Ñ´Èê½­³ØÎÛÌÀ¼³µÆ»ÒÒ¯Ä²°ÙÆîÖñÃ×ºìÏËÔ¼¼¶¼ÍÈÒÍøÑòÓðÀÏ¿¼¶ø¶úÈâÀß¼¡³¼×ÔÖÁ¾ÊÉàÖÛÉ«ÓóÉÖÃ¢Ö¥³æÑªÐÐÒÂÎ÷¹Û½²»äÑÈÐí¶ïÂÛËÏ·íÉè·Ã¾÷Õê¸º¹ì´ïÇ¨ÓØÆùÑ¸¹ýÂõÐÏÄÇ°îÐ°±ÕÎÊ´³Èî·ÀÑôÒõÕó½×Ò³ÍÔÑ±³ÛÆëÁ½ÑÏ´®ÀöÂÒºàÄ¶²®¹À°éÁæÉìËÅËÆµèµ«Î»µÍ×¡×ôÓÓÌåºÎÓà·ð×÷ÄãÓ¶¿ËÃâ¶Ò±ø¿öÒ±Àä¶³³õÉ¾ÅÐÅÙÀû±ðÖúÅ¬½ÙÀø¾¢ÀÍÏ»Ò½Â±¼´È´ÂÑÏØ¾ýÁßÍÌÒ÷·Í·ñ°É¶Ö·Ôº¬Ìý¿ÔË±ÆôÖ¨Îâ³³Îü´µÎÇºðÎáÑ½´ô³Ê¸æÄÅÅ»Ô±ÇºÎØ¶ÚÔ°À§´ÑÎ§Ö·¾ù·»Ì®¿²»µ×ø¿Ó¿é¼áÌ³°ÓÎë·Ø×¹Éù¿ÇÈÑ¶Ê¼ËÑýÃîÍ×·Á×ÎÐ¢ËÎÍêºêÊÙÎ²Äò¾ÖÆ¨²ã²í¸ÚµºÏ£ÕÊ±Ó´²ÐòÂ®¿âÓ¦ÆúÅªµÜÕÅÐÎÍ®ÒÛ³¹¼ÉÈÌÖ¾ÍüÓÇ¿ì³ÀÐÃ»³ÎÒ½äÅ¤°ç³¶ÈÅ°â·öÅú¶óÕÒ¼¼³­¾ñ°ÑÒÖÊã×¥Í¶¶¶¿¹ÕÛ¸§Å×¿ÙÂÕÇÀ»¤±¨¾ÜÄâ¸Ä¹¥ºµÊ±¿õ¸ü¸ËÉ¼ÀîÐÓ²Ä´åÕÈ¶ÅÊø¸ÜÌõÀ´Ñî¼«²½¼ßÃ¿Çó¹¯ÍôÌ­ÐÚÆû·ÚÇßÒÊÎÖÉò³ÁÆãÉ³Åæ¹µÃ»Å½Á¤ÂÙ²×»¦·ºÁéÔî¾Ä×ÆÔÖ²ÓÄµÀÎ×´ÓÌ¿ñµÒ±·¾ÁÂê¸¦ÄÐµéÁÆÔí¶¢ÒÓÉçÐãË½Íº¾¿ÇîÏµÎ³´¿É´¸ÙÄÉ×ÝÂÚ·×Ö½ÎÆ·ÄÅ¦º±Ç¼Ð¤Öâ¶Ç¸Ø¸Î³¦Á¼Îß½æÂ«·Ò°ÅÐ¾»¨·¼ÇÛÑ¿Î­²ÔËÕ²¹½ÇÑÔÖ¤ÆÀ×çÊ¶Õ©ËßÕïÖß´ÊÒë¹È¶¹¹±²Æ³à×ß×ãÉíÐùÐÁ³½Ó­ÔË½ü·µ»¹Õâ½øÔ¶Î¥Á¬³ÙÒØÓÊºªÇñÉÛ×ÞÁÚÓÏÀïÕë¶¤ÈòÏÐ¼äÃÆ×è°¢ÍÓ¸½¼ÊÂ½Â¤³ÂÈÍ·¹ÒûÇý²µÂ¿¼¦Âó¹êÉ¥¹ÔÈéÊÂÐ©Ïí¾©ÅåÀÐÑð°Û¼ÑÊ¹Ö¶³ÞÀýÊÌ¶±¹©ÒÀÏÀÂÂ½ÄÕì²àÇÈ¿ëÍÃÆä¾ßµä¾»Æ¾¿­º¯¹Îµ½ÖÆË¢È¯É²´Ì¿Ì¹ô¶ç¼ÁÊÆ±°×ä×¿µ¥ÂôÎÔ¾í²ÞÈþ²ÎÊåÈ¡ÄØÖÜÎ¶ºÇÅÞÉëºôÃü¾×ÅØÕ¦ºÍ¾ÌÓ½¸ÀÖä¹¾¿§Áü°¥¹Ì¹úÍ¼ÆÂÀ¤Ì¹ÆºÅ÷¿À´¹À¬Â¢±¸Ò¹ÑÙÆæÄÎ·î·Ü±¼ÄÝÃÃÆÞÄ·Ê¼½ã¹ÃÐÕÎ¯ÃÏ¼¾¹ÂÑ§×Ú¹ÙÖæ¶¨ÍðÒË±¦Êµ³èÉóÉÐ¾ÓÇüÌë½ìÑÒÁëÔÀ°¶¿ùÎ×ÅÁÌûÁ±Öã²¯ÖÄÐÒµ×µêÃí¸ý¸®ÅÓ·Ï½¨ÃÖÏÒ»¡Â¼±ËÍùÕ÷¾¶ÖÒÄîºö·ÞÌ¬ËËÕúÅÂ²ÀÁ¯ÐÔ¹ÖÇÓ»ò·¿Ëù³ÐÅêÅûÌ§±§µÖÄ¨Ñº³éÃò·÷Öôµ£²ðÄ´ÄéÀ­°èÅÄÁà¹ÕÍØ°ÎÍÏ¾Ð×¾ÕÐÂ£¼ðÓµÀ¹Å¡²¦Ôñ·Å¸«Õ¶Íú°ºÀ¥²ýÃ÷»èÒ×ÎôÅó·þº¼±­½ÜËÉ°å¹¹Í÷ÎöÕíÁÖÃ¶¹ûÖ¦ÊàÔæÇ¹·ã¹ñÐÀÅ·ÎäÆçÅ¹Ã¥·ÕÄ­¾ÚºÓ·ÐÓÍÖÎÕÓ¹ÁÕ´ÑØÐ¹Çö²´ÃÚ·¨Å¢ÅÝ²¨ÆüÄà×¢ÀáÓ¾ÐºÆÃÔóÇ³Â¯´¶Ñ×³´È²¿»ÖË¾æÅÀ°Ö°æÄÁÎïºü¹·¾ÑÄüÍæÃµ»·ÏÖÎÍ»­³©¸í¾ÎÅ±ÑñµÄÓÛÃ¤Ö±ÖªÎù·¯¿óÂëÆí¸Ñ±ü¿ÕÏßÁ·×éÉðÏ¸Ö¯ÖÕ°íÉÜÒï¾­ÂÞÕßÒ®Ëà¹ÉÖ«·ô·Ê¼ç·¾°¹¿ÏÓý·ÎÉöÖ×ÕÍÐ²Éá¼èÔ·Ì¦Ãç¿Á°ú¹¶Èô¿àÉ»±½Ó¢Æ»×ÂÃ¯·¶ÇÑÃ©¾¥»¢Â²Ê­±íÉÀ³Ä¹æÃÙÊÓÊÔÊ«³ÏÖï»°µ®¹îÑ¯Òè¸ÃÏê²ïÔðÏÍ°ÜÕË»õÖÊ··Ì°Æ¶±á¹ºÖü¹á×ªÂÖÈíºäÌöµÏÆÈµüÊöÓô½¼ÀÉÖ£²É½ðÇ¥·°µöÕ¢ÄÖ¸·ÂªÄ°½µÏÞÉÂÁ¥ÓêÇà·Ç¶¥Çê½¤ÊÎ±¥ËÇÊ»¾Ô×¤ÍÕ¼ÝÓãÃù³ÝÁÙ¾ÙÍ¤ÁÁÇ×ÎêºîÇÖ±ã´Ù¶í¿¡ÇÎÀþË×·ý±£ÓáÐÅÁ©¼óÐÞ×ÈÑøÃ°¹ÚÌêÏ÷Ç°¹Ð½£²ªÓÂÃãÑ«ÄÏÐ¶ÀåºñÊÜ±äÐðÅÑ×ÉÒ§¿©ÔÛ¿ÈÏÌÑÊ°§Æ·ºå¶ßÍÛ¹þÔÕÏìÑÆ»©Ó´ÄÄÐÍÀÝ¶â¹¸Ô«¿Ñµæ¿å³Ç¸´¿ü×àÆõ½±Ò¦½ªÀÑÒÌÒö×ËÍþÍÞÂ¦½¿ÄÈº¢ÂÏ¿ÍÐûÊÒ»ÂÏÜ¹¬·â½«³¢ÎÝÊºÆÁÖÅÏ¿ÂÍ²îÏïµÛ´øÖ¡°ïÓÄ¶ÈÍ¥ÍäÑå±ë´ýºÜ»²ÂÉÔõÅ­Ë¼µ¡¼±Ô¹×ÜÊÑ»Ðºã»ÖÐôºÞ¶²ÌñÄÕÕ½±â°ÝÀ¨ÊÃÕü¹°Ë©¿½Æ´×§Ê°³Ö¹ÒÖ¸°´¿æÌôÍÚÎÎÌ¢Ð®ÄÓµ²Õõ¼·»ÓÅ²Í¦Õþ¹ÊÊ©¼ÈÐÇÓ³´ºÃÁ×òÕÑÊÇÖçÏÔ¿Ý¼Ü¼Ï±ú°ØÄ³¸ÌÆâÈ¾Èá×õÄû²é¼í¿ÂÖùÁøÊÁÕ¤±êÕ»¶°À¸Ê÷ÍáÑê´ù²Ð¶Î¶¾±ÑÅþÕ±·úÇâÈª±Ã½àÑóÈ÷Ï´Âå¶´½òºé¶ýÖÞ»îÍÝÇ¢ÅÉ½½×Ç²â¼Ã»ëÅ¨ÏÑÌ¿ÅÚ¾¼±þÕ¨µãÁ¶³ãË¸ÀÃÌþÉüÇ£ºÝ½Æ¶ÀÏÁÊ¨ÕøÓüÁá²£ÉºÕä·©Éõ±Â½çÎ·°Ì½êÒß´¯·è¹ï½Ô»ÊÖÑÅèÓ¯ÏàÅÎ¶ÜÊ¡Ã¼¿´Õ£¾ØÉ°Æö¿³ÅøÑÐ×©Ñâ×æ×£ÉñÓíÇïÖÖ¿ÆÃë´©Í»ÇÔÊú¸ÍÀà×Ñ°óÈÞ½áÈÆ»æ¸øÑ¤Âç¾ø½ÊÍ³¸×·£ÃÀË£ÄÍÎ¸µ¨±³Ì¥ÅÖÅßÊ¤°ûºúÂö¼ë´ÄÃ£²çÒð²èÈ×Èã¾£²Ý¼ö»ÄÀó¼Ôµ´ÈÙ»çÓ«ÒñÒ©Å°ºçËäÏºÊ´ÒÏÂìÔéÑÜ°ÀÒªÀÀ¾õ½ëÎÜÓïÎóÓÕ»åËµËÐ·¡¼úÌù¹ó´ûÃ³·ÑºØ¸°ÕÔÅ¿ÖáÇáÃÔ±Å¼£×·ÍËËÍÊÊÌÓÄæÑ¡Ñ·ºÂ¿¤ÔÇÇõÖØ¸Æ¶Û³®ÖÓÄÆ±µ¸ÖÔ¿ÇÕ¾ûÎÙ¹³Å¥¹ëÎÅÃö·§¸óºÒ±Ý¶¸Ôº³ýÔÉÏÕÃæ¸ï¾ÂÒôÏîË³ÐëÊ³¶üÈÄ½È±ýÊ×ÏãÂî½¾Âæº§¹Ç¹íÅ¸Ñ»³Ë¸©¾ã°³±¶µ¹¾óÌÈºòÒÐ½è³«¾ëÄßÕ®ÖµÇã½¡µ³¼æÔ©Æà×¼Á¹µòÁèÌÞÆÊ°þ¾ç·ËÄäÇäÔ­¸çÅ¶ÉÚÁ¨¿ÞÏøÕÜ²¸ºßÑäËô´½°¦ÌÆ»½°¡ÆÔÔ²¹¡°£ÂñÆÒºøÏÄÌ×¼§Äï¾êÉï¶ðÃäÓéÔ×º¦ÑçÏü¼ÒÈÝ¿í±öÉäÐ¼Õ¹¶ëÓøÇÍ·å¾þÏ¯×ùÈõÐìÍ½Áµ¿ÖË¡¶÷¹§Ï¢¿Ò¶ñÇÄº·»ÚÎòÔÃÃõÉÈÈ­ÄÃÖ¿ÂÎ°¤´ìÕñÍìÎæÍ±À¦×½°Æº´ÉÓÄó¾è²¶ÀÌËð¼ñ»»µ·Ð§µÐ°½Õ«ÁÏÅÔÂÃ»Î½úÉÎÉ¹ÏþÔÎÍíË·ÀÊ²ñË¨ÆÜÀõÐ£ÖêÑùºË¸ù¸ñÔÔ¹ðÌÒÎ¦¿ò°¸×ÀÍ©É£»¸½ÛµµÇÅ½°×®°ðÉÒÎàÀæÑ³ÊâÒó±Ðº¤Ñõ°±Ì©Á÷½¬Õã¿£ÆÖºÆÀË¸¡Ô¡º£½þÍ¿ÄùÏûÉæÓ¿ÌéÌÎÀÔÁ°ÎÐ»ÁµÓÈó½§ÕÇÉ¬ÁÒºæÀÓÖòÑÌ¿¾·³ÉÕ»âÌÌ½ýÈÈ°®µùÌØÎþÀêÀÇÖé°àÆ¿´ÉÅÏÁôÐóÆ£ÕîÌÛ¾Ò¼²²¡Ö¢Ó¸¾·¸ÞÖåÒæ°»ÕµÑÎ¼àÕæÃßÑ£ÕèÅéÆÆÉéÔÒÀù´¡ËîÏéÀëÃØ×â³ÓÇØÑíÖÈ»ý³ÆÕ­ÇÏÕ¾¾º°ÊËñÐ¦±Ê·ÛÎÉËØË÷½ô¾îÐåËçÌÐ¼ÌÈ±°Õ¸áÐßÎÌ³á¸ûºÄÔÅ°ÒËÊ³Üµ¢¹¢Äô¿èÒÈ¸ì½ºÐØ°·ÄÜÖ¬´à¼¹ÔàÆêÄÔÅ§³ôÖÂÒ¨º½°ã½¢²ÕÑÞºÉÆÎÀòÉ¯ÄªÀ³Á«»ñÓ¨Ã§ÂÇÎÃ°ö²ÏÑÁË¥ÖÔÔ¬ÅÛÌ»ÐäÍà±»ÇëÖîÅµ¶Á·Ì¿ÎË­µ÷ÁÂ×»Ì¸Òê±ª²òÔô¼Ö»ßÁÞÂ¸Ôß×Ê¸ÏÆð¹ªÔØ½Î½ÏÈèÍ¸ÖðµÝÍ¾¶ºÍ¨¹äÊÅ³ÑËÙÔì·ê²¿¹ù³»µ¦¶¼×ÃÅä¾Æ¸ªÇ®Ç¯²§×ê¼ØÓËÌú²¬ÁåÇ¦Ã­ÔÄÅãÁêÌÕÏÝÄÑÍç¹Ë¶Ù°äËÌÔ¤¶öÄÙ³ÒÑé¿¥¸ßÑ¼ÑìÔ§ÍÒÇ¬¼ÙÆ«×öÍ£Å¼Íµ³¥¿þ¶µÊÞÃá¼õ´Õ»Ë¼ô¸±ÀÕ¿±³×Ïá¾Ç»£ÊÛÎ¨³ªÍÙ¿Ð×ÄÉÌ·ÈÆ¡É¶À²Å¾ÄöÐ¥È¦Óò²ºÅà»ùÌÃ¶ÑÇµ¶é¶Â¹»ÉÝÈ¢ÆÅÍñ»éÀ·Ó¤ÉôÊëËÞ¼Å¼ÄÒúÃÜ¿ÜÎ¾ÍÀ³çÆé´ÞÑÂ±ÀÕ¸³²³£Êü¿µÓ¹ÀÈµ¯²Ê±òµÃÅÇÓÁÏ¤ÓÆ»¼ÄúÐü¼Âµ¿Çé¾ªÍïÌèÏ§Î©µë¾å²Ò²Ñµ¬¹ßÆÝÅõ¾Ý´·½ÝÄíÏÆµà¶ÞÊÚµôÌÍÆþÅÅÒ´¾òÂÓÌ½½Ó¿ØÍÆÑÚ´ëÂ°ÖÀµ§²ôÃô¾È½ÌÁ²±Ö¸ÒÐ±¶ÏÐý×åÎî»Þ³¿²ÜÂüÍûÍ°ÁºÃ·¹£ÃÎËóÌÝÐµÊá¼ìÓûºÁ¸¢ÑÄÒºº­ºÔµí×ÍÏýÁÜÌÊÊçÄ×ÌÔµ­ÓÙÒù´ã»´Éî´¾»ìÑÍÌíÇåÔ¨×Õ½¥ÓæÉøÇþÏ©ÍéÅë·éÑÉº¸»ÀË¬ÀçÁÔ²þÃÍ²ÂÖíÃ¨ÂÊÇòÀÅÀíÁðËöÌðÂÔÆè´ÃÈ¬Ñ÷ÖÌºÛ°¨ºÐ¿ø¸ÇµÁÅÌÊ¢ÃÐ¿ô¾ìÌ÷ÑÛ×ÅÕö½Ã¹èÎøË¶Æ±¼Àµ»»ö½ÕÒÆ»àÒ¤ÖÏ¾¹ÕÂµÑ·û±¿µÚ¼ãÁýÁ£ÆÉ´ÖÕ³ÀÛ¼¨Ð÷Ðø´ÂÉþÎ¬Ãà±Á³ñ×ÛÕÀÂÌ×ºÁçÒîÁÄÁûÖ°²±½Å¸¬ÍÑÁ³¶æ²°ÏÏ´¬¹½¾Õ¾úºÊ²Ë²¤ÆÐÁâ·ÆÌÑÃÈÆ¼Î®ÂÜÓ©ÓªÏôÈøÖøÐéÖûÇùÉß¹Æµ°ÐÆÏÎ´üÏ®¸¤Ä±µý»ÑÐ³Î½²÷ÑèÃÕÏóÉÞÉâÖºÔ¾¾àÇû¸¨Á¾´þÒÝÂß¶õÐï·ÓÔÍÌªÒ°Í­ÂÁÕ¡Ï³¸õÃú½ÂÒ¿²ùÒøÑËÑÖ²ûÓçÂ¡ËåËæÒþÈ¸Ñ©Â­ÁìÆÄ¾±ÏÚ¹ÝÆï¸ëºèÂ¹Âé»Æ¹¨¸µÀü°ø´ö´¢°ÁÔäÊ£¸îÄ¼²©ÏÃ³øÌä¿¦Î¹ÉÆÀ®ºíº°´­Ï²ºÈÐúÔûÅçÓ÷±¤µÌ¿°ÑßËþÒ¼µì°ÂÐöÃ½ÃÄÉ©¸»ÃÂº®Ô¢×ð¾ÍÊôÂÅÇ¶Ã±ÃÝ·ùÇ¿ÅíÓùÑ­±¯»ó»Ý³Í±¹¶è»ÌÈÇÐÊÓä·ßÀ¢»Å¿®ÕÆ³¸Èà×áÃèÌá²åÒ¾ÎÕ´§¿«¾¾½ÒÔ®À¿²ó¸éÂ§½Á´êÉ¦ËÑ´î²ë³¨É¢¶Ø¾´±ó°ßË¹ÆÕ¾°ÎúÇç¾§ÖÇÁÀÔÝÊîÔøÌæ×î³¯ÆÚÃÞÆå¹÷°ô×Ø¼¬ÅïÌÄÉ­Àâ¿Ã¹×ÒÎÖ²×µ½·ÍÖÒ¬ÀÆÆÛ¿îÖ³ÌºµªÂÈÇèÓå¶ÉÔü²³ÎÂÎ¼¸Û¿ÊÓÎÃìÅÈÍÄºþÏæÕ¿ÍåÊªÀ£½¦¸È³ü×Ì»¬ÖÍ±º·Ù½¹ÑæÈ»ÖóÅÆÏ¬¶¿ÐÉºï»«×ÁÁÕÇÙÅýÅÃÇíÉû·¬³ëÊè¶»Í´Æ¦Á¡»¾µÇÍî¶ÌÏõÁòÓ²È·¼ïÂ»ÇÝÏ¡³ÌÉÔË°½Ñ´°¾½´ÜÎÑ¿¢Í¯µÈ½î·¤¿ðÖþÍ²´ð²ßÉ¸ËÚÔÁÖà·à×ÏÐõ¼êÃåÀÂ¼©¶Ð»ºµÞÂÆ±àÔµÏÛÏèÇÌÁªÆ¢ÌóÀ°Ò¸¸­Ç»ÍóÊæË´Í§Âä¸ðÆÏ¶­ºùÔá´Ð¿ûµÙ½¯»×ÍÜÖë¸òÂùÕÝÑÑ½Ö²ÃÁÑ×°Ô£È¹¿ãÐ»Ò¥°ùÇ«¸³¶ÄÊêÉÍ´ÍÅâ³Ã³¬Ô½Ç÷°ÏµøÅÜ¼ù±²»Ô¹õ¹¼±ÆÓâ¶ÝËìÓö±é¶ôµÀÒÅº¨ËÖÓÔÊÍÁ¿ÖýÆÌÁ´ÏúËø³ú¹øÐâ·æÐ¿ÈñÌàÀ»À«¸ô°¯Ï¶ÑãÐÛÑÅ¼¯¹Íº«¼ÕÀ¡²öÆ­É§Â³¾é¶ìÊòºÚ¶¦´ßÉµÏñ½ËÇÚµþÐáÉ¤ÊÈÎËËÃËúËÜÌÁÈûÌîÄ¹Ï±¼Þ¼µÏÓÇÞÄ¯»ÏÄ»Á®ÀªÎ¢Ïë³îÓúÒâÓÞ¸Ð´ÈÉ÷Éå²«´¤¸ãÌÂ°áÐ¯Éã°ÚÒ¡±÷Ì¯ÃþÊýÕåÐÂÏ¾Å¯°µ´ª´»Ð¨³þÀã¿¬Â¥¸ÅÓÜ»±Ðª¸èµî»ÙÔ´ÁïÒçÏªËÝÈÜÄçµá×ÒÌÏ¹öÂúÂËÀÄÂÐ±õÌ²ÀìÄ®»Í¼åÉ·ÃºÕÕÏ×Ô³º÷ÈðÉª¹åÕç»ûÌµ³Õ±Ô´áÃË¾¦Ë¯¶½ÄÀ½Þ²Ç¶ÃÃé°«ÅðµïÂµ°­Ëé±®ÍëµâÅö½û¸£°ÞÖÉ³í¿ß¿ú¿ê³ïÇ©¼òÁ¸Á»¾¬¸¿·ì²øÕÖ×ïÖÃÊðÈºÆ¸ÒÞËÁÐÈÈùÑü¸¹ÏÙÄåÌÚÍÈ¾ËÃÉËâÆÑÕôÐîÈØËò±ÍÀ¶¼»ÅîÓÝÓ¼¶ê·äÍÉÎÏÑÃÒáÂã¹Ó½â´¥Õ²ÓþÌÜ½÷Ã¡Ãý»¿ºÑÀµ¸ú¿ç¹òÂ·Ìø¶å¶ã·ø¼­Êä´Ç±ÙÇ²Ò£±ÉÀÒ³êÍª½´¼øÕà´íÃªÎýÂà´¸×¶½õÏÇ¶§¼ü¾âÃÌÕÏÓº³ûÁãÀ×±¢Îí¾¸½ùÑ¥°ÐÔÏÒÃÆµÍÇÓ±Áó¿ý»ê±«ÈµÅô¹ÄÊóÁäÁÅÉ®ËÛ¾¤µÊËÔ¼Î¸ÂÐêÂï¾³ÊûÉÊÇ½µÕÄÛ·õ²ì¹ÑÁÈÕ¯ÁÎ±×ÕÃÔ¸Ä½Âý¿¶½ØË¤Õª´ÝÄ¡ÁÌÆ²ÇÃÎÓÆì°ñÕ¥ÁñÈ¶¼÷Ä£Ç¸µÎÆ¯ÆáÂ©ÑÝÂþÊþÕÄÑúÎ«É¿Ï¨ÐÜÑ¬ÈÛÎõ°¾ÑþÁ§ÒÉÎÁÊÝ´ñ³òµú±Ì¼îÌ¼²ê´Å´èÎÈ½ß¶Ë¹¿²­»þËã¹ÜÂá´â¾«Ó§ËõµÔ´ä¾ÛÕØ¸¯°ò²²¸àÄ¤ÓßÌòÎèÃïÂûÕáÎµ²ÌÄèÇ¾°ª±ÎÊñÖ©ÃÛÀ¯Ó¬²õÉÑÅá¹üºÖÍÊÊÄÌ·À¾Æ×ºÀÃ²×¸×¬ÈüºÕÓ»³ìÔ¯Ï½Õ·À±ÔâÕÚ½ÍÃ¸¿áËáÄðÇÂ¶Í¶ÆÃ¾Ëí´ÆÐè¾²ÉØ¿ÅÂøÂâÆÇÏÊ±Ç½©Æ§ÁÝÅüÖö³°Ë»ÎûºÙÒ­¸ÁÔöÐæÄ«¶ÕÂÄ´±Ó°µÂ»ÛÎ¿±ïÔ÷º©¶®Â¾Ä¦¾ï³ÅÈöËº×²³·ÁÃÇË²¥´é×«ÄìÇÜ·óÄº±©²Û·®ÕÁºáÓ£ÏðÒãÅËÇ±ÁÊÌ¶³±³Î³ºÅìÀ½°ÄÊìÁö±ñÌ±Ï¹Â÷Äë°õÀÚÅÍ¿Äµ¾¼Ú»ü¸å¼ýÏä×­ÆªÂ¨ºýÉÉ´Ï±ìÌÅÏ¥ËÒÊß½¶ÈïÔÌÐ«»Èºûµû°ýÈìÇ´ÍãÔ¥ÌËÈ¤Ì¤¾áÌß²È×ÙÌÉ×ñ´¼×í´×ÕòÄ÷Äø¸ä°÷ÏöÕðÃ¹¿¿Ð¬°°ÌâÑÕ¶îÆ®º¡Àðº×ÀèÈå¼½Äý×ìÆ÷ÔëÊÉ±Úº¶Ð¸°ÃÀÁº³ÀÞÉÃ²ÙÇæËÓÕûÇÁ³È³÷ÂºÔè¼¤±ôÈ¼ÁÇÑàÌ¡Æ°ÕÎÈ³Æ³Ä¥»ÇÄÂÁþ¸Ý´ÛÀºÀéÅñ¸âÌÇ²Ú½Éº²°¿ÅÕÅòÉÅÕéÀÙ±¡Ñ¦Ð½ÊíÈÚÃøºâÔÞÔùÌãÕÞ±æ±ç±ÜÑûÐÑÃÑÈ©¾µµñ»ôÄÞÁØµåÇÊµß²Í¾¨Ç­Ä¬ÀÜº¿Ìçº¾Èæ»ÕÅ³´÷²ÁÊïÌ´Ï­ÃÊÔï¾ô°©ÇÆÖõµÉË²Í«Á×½¸Ëë´Ø»ÉÃÓÔã¿··±ÒíÍÎ±ÛÓ·ÒÜ½å²ØÃêÂÝÏå»íÉÄÓ®µ¸Ì£±èÁÍËªÏ¼¾ÏÖèÎºÈúÈ£ÏùÒÍ´ÁÆÙÕ°·­ÅºÌÙ·ª½ó¸²±Ä³ùÀØÁ­±Þ××Ó¥ÄõÅÊÔÜÆØ±¬°ê½®Ñ¢²¾¸þÔåÄ¢Ð·¾¯µÅ²ä¶×´ÚÃÒ²ü±îÂ´ÈÂ½ÀÈÀÎ¡ÈÁ¹à¼®Å´×ëÒ«ÈäÆ©ÔêÄ§ÁÛ´À¸ÓÂ¶°ÔÅùËèÄÒÈ¿ÕºÏâ¾ð¹ÞÈ§´£";
function judge_CN(char1,char2,mode){
	var charSet=charMode?charPYStr:charBHStr;
	for(var n=0;n<(char1.length>char2.length?char1.length:char2.length);n++){
		if(char1.charAt(n)!=char2.charAt(n)){
			if(mode) return(charSet.indexOf(char1.charAt(n))>charSet.indexOf(char2.charAt(n))?1:-1);
			else	 return(charSet.indexOf(char1.charAt(n))<charSet.indexOf(char2.charAt(n))?1:-1);
			break;
		}
	}
	return(0);
}

function sort_tab(the_tab,col,mode){
	var tab_arr = new Array();
	var i;
	var start=new Date;
	for(i=1;i<the_tab.rows.length;i++){
		tab_arr.push(new Array(the_tab.rows[i].cells[col].innerText.toLowerCase(),the_tab.rows[i]));
	}
	function SortArr(mode) {
		return function (arr1, arr2){
			var flag;
			var a,b;
			a = arr1[0];
			b = arr2[0];
			if(/^(\+|-)?\d+($|\.\d+$)/.test(a) && /^(\+|-)?\d+($|\.\d+$)/.test(b)){
				a=eval(a);
				b=eval(b);
				flag=mode?(a>b?1:(a<b?-1:0)):(a<b?1:(a>b?-1:0));
			}else{
				a=a.toString();
				b=b.toString();
				if(a.charCodeAt(0)>=19968 && b.charCodeAt(0)>=19968){
					flag = judge_CN(a,b,mode);
				}else{
					flag=mode?(a>b?1:(a<b?-1:0)):(a<b?1:(a>b?-1:0));
				}
			}
			return flag;
		};
	}
	tab_arr.sort(SortArr(mode));

	for(i=0;i<tab_arr.length;i++){
		the_tab.lastChild.appendChild(tab_arr[i][1]);
	}	
}