function main(){(function(){'use strict'
function menubar_height(){jQuery('.rst-header-banner').css('padding-top',jQuery('.rst-header-menu-bar').height()+'px');}function menu(){$('.rst-menu-trigger').on('click',function(){$('.rst-header-menu ul').stop(false,false).slideToggle('fast');return false;});}var letsticky=0;function header_sticky(){if(jQuery(window).scrollTop()>jQuery('#rst-header').height()&&letsticky==1){jQuery('.rst-header-menu-bar').addClass("rst-sticky");}else{jQuery('.rst-header-menu-bar').removeClass("rst-sticky");}}jQuery(document).ready(function(jQuery){new WOW().init();jQuery('.rst-languages > a').on('click',function(e){e.preventDefault();jQuery('.rst-languages ul,.rst-account ul,.rst-login form').stop(false,false).slideUp(200);jQuery('.rst-languages ul').stop(false,false).slideToggle(200);});jQuery('.rst-account > a').on('click',function(e){e.preventDefault();jQuery('.rst-languages ul,.rst-account ul,.rst-login form').stop(false,false).slideUp(200);jQuery('.rst-account ul').stop(false,false).slideToggle(200);});jQuery('.rst-login > a').on('click',function(e){e.preventDefault();jQuery('.rst-languages ul,.rst-account ul,.rst-login form').stop(false,false).slideUp(200);jQuery('.rst-login form').stop(false,false).slideToggle(200);});jQuery('.rst-back-top a').on('click',function(e){e.preventDefault();jQuery('html, body').animate({scrollTop:0},'slow');});jQuery('.rst-header-livechat').on('click',function(e){e.preventDefault();jQuery('#rst-support-online').css('display','block');});jQuery('.btn-file :file').on('fileselect',function(event,numFiles,label){});jQuery('#rst-support-online header > a').on('click',function(e){e.preventDefault();jQuery('#rst-support-online').css('display','none');});jQuery('.rst-login form').validate();jQuery('.rst-signin form').validate();jQuery('.comment-form').validate();jQuery('.rst-account-settings form').validate();jQuery('.rst-contact-form form').validate();var postowl=jQuery('.rst-single-slider');postowl.owlCarousel({loop:true,autoplay:true,items:1,singleItem:true,transitionStyle:"fadeUp",afterAction:function(elem){var current=this.currentItem;jQuery('.rst-single-post-slider > p span:first-child').html(current+1);}});jQuery('.rst-single-post-slider > p span:last-child').html(jQuery('.rst-single-slider .owl-item').size());jQuery(".rst-whatwehave-owl").owlCarousel({items:1,singleItem:true,navigation:true,transitionStyle:"backSlide",navigationText:['<i class="fa fa-arrow-left"></i>','<i class="fa fa-arrow-right"></i>'],pagination:true,});jQuery(".rst-whatpeople-owl").owlCarousel({items:1,singleItem:true,navigation:true,navigationText:['<i class="pe-7s-left-arrow"></i>','<i class="pe-7s-right-arrow"></i>'],pagination:false,});jQuery('.counter').counterUp();jQuery('.rst-scroll-down a').on('click',function(e){var offsettop=jQuery(this).parents('.wpb_row').next().offset().top;e.preventDefault();jQuery('html, body').animate({scrollTop:offsettop,},'slow');});jQuery('.fancybox-media').fancybox({type:'iframe',});jQuery('.fancybox').fancybox({});jQuery('.rst-theteam-select .nav-tabs li a').on('click',function(){var dataimg=jQuery(this).attr('data-img');for(var i=1;i<=jQuery('.rst-theteam-img').size();i++){var dataimg2=jQuery('.rst-theteam-img').eq(i-1).attr('data-img');if(dataimg===dataimg2){jQuery('.rst-theteam-img').removeClass('active');jQuery('.rst-theteam-img').eq(i-1).addClass('active');}}});jQuery('#package').ddslick();jQuery('.rst-contact-form select').ddslick();jQuery("#country").countrySelect();if(jQuery('#cd-google-map').length!=0){var latitude=12.961280,longitude=79.139965,map_zoom=13;var marker_url='images/icon//map-location.png';var style=[{"featureType":"water","elementType":"geometry.fill","stylers":[{"color":"#d3d3d3"}]},{"featureType":"transit","stylers":[{"color":"#808080"},{"visibility":"off"}]},{"featureType":"road.highway","elementType":"geometry.stroke","stylers":[{"visibility":"on"},{"color":"#b3b3b3"}]},{"featureType":"road.highway","elementType":"geometry.fill","stylers":[{"color":"#ffffff"}]},{"featureType":"road.local","elementType":"geometry.fill","stylers":[{"visibility":"on"},{"color":"#ffffff"},{"weight":1.8}]},{"featureType":"road.local","elementType":"geometry.stroke","stylers":[{"color":"#d7d7d7"}]},{"featureType":"poi","elementType":"geometry.fill","stylers":[{"visibility":"on"},{"color":"#ebebeb"}]},{"featureType":"administrative","elementType":"geometry","stylers":[{"color":"#a7a7a7"}]},{"featureType":"road.arterial","elementType":"geometry.fill","stylers":[{"color":"#ffffff"}]},{"featureType":"road.arterial","elementType":"geometry.fill","stylers":[{"color":"#ffffff"}]},{"featureType":"landscape","elementType":"geometry.fill","stylers":[{"visibility":"on"},{"color":"#efefef"}]},{"featureType":"road","elementType":"labels.text.fill","stylers":[{"color":"#696969"}]},{"featureType":"administrative","elementType":"labels.text.fill","stylers":[{"visibility":"on"},{"color":"#737373"}]},{"featureType":"poi","elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"featureType":"poi","elementType":"labels","stylers":[{"visibility":"off"}]},{"featureType":"road.arterial","elementType":"geometry.stroke","stylers":[{"color":"#d6d6d6"}]},{"featureType":"road","elementType":"labels.icon","stylers":[{"visibility":"off"}]},{},{"featureType":"poi","elementType":"geometry.fill","stylers":[{"color":"#dadada"}]}];var map_options={center:new google.maps.LatLng(latitude,longitude),zoom:map_zoom,panControl:false,zoomControl:false,mapTypeControl:false,streetViewControl:false,mapTypeId:google.maps.MapTypeId.ROADMAP,scrollwheel:false,styles:style,}
var map=new google.maps.Map(document.getElementById('google-container'),map_options);var marker=new google.maps.Marker({position:new google.maps.LatLng(latitude,longitude),map:map,visible:true,icon:marker_url,});}if(jQuery("#contactForm").length){jQuery("#contactForm input,#contactForm textarea").jqBootstrapValidation({preventSubmit:true,submitError:function(jQueryform,event,errors){},submitSuccess:function(jQueryform,event){event.preventDefault();var name=jQuery("input#contact-name").val();var email=jQuery("input#contact-email").val();var subject=jQuery("input#contact-subject").val();var category=jQuery(".dd-selected-text").html();var message=jQuery("textarea#contact-message").val();var firstName=name;if(firstName.indexOf(' ')>=0){firstName=name.split(' ').slice(0,-1).join(' ');}jQuery.ajax({url:"././submit.php",type:"POST",data:{name:name,email:email,subject:subject,category:category,message:message,},cache:false,success:function(){jQuery('#success').html("<div class='alert alert-success'>");jQuery('#success > .alert-success').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;").append("</button>");jQuery('#success > .alert-success').append("<strong>Your message has been sent. </strong>");jQuery('#success > .alert-success').append('</div>');jQuery('#contactForm').trigger("reset");},error:function(){jQuery('#success').html("<div class='alert alert-danger'>");jQuery('#success > .alert-danger').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;").append("</button>");jQuery('#success > .alert-danger').append("<strong>Sorry "+firstName+", it seems that my mail server is not responding. Please try again later!");jQuery('#success > .alert-danger').append('</div>');jQuery('#contactForm').trigger("reset");},})},filter:function(){return jQuery(this).is(":visible");}});}jQuery('.rst-loadmore').on('click',function(e){e.preventDefault();var load_more=jQuery(this);load_more.html('<i class="fa fa-refresh fa-spin"></i> Loading...');setTimeout(function(){load_more.html('<i class="fa fa-refresh"></i> load more');var data='\
					<div class="col-sm-4">\
						<div class="rst-product-box">\
							<div class="rst-box-image">\
								<img alt="" src="http://placehold.it/370x450">\
								<div class="rst-box-overlay ">\
									<a class="btn btn-primary" href="#">start support</a>\
									<a class="btn btn-success" href="#">live chat</a>\
								</div>\
							</div>\
							<div class="rst-box-data">\
								<h4><a href="product-single.html">Run road</a></h4>\
								<div class="rst-box-metadata">\
									<div class="rst-meta"><span>20 articles</span></div>\
									<div class="rst-meta"><span>web design</span></div>\
									<div class="clear"></div>\
								</div>\
							</div>\
						</div>\
					</div>\
					<div class="col-sm-4">\
						<div class="rst-product-box">\
							<div class="rst-box-image">\
								<img alt="" src="http://placehold.it/370x450">\
								<div class="rst-box-overlay ">\
									<a class="btn btn-primary" href="#">start support</a>\
									<a class="btn btn-success" href="#">live chat</a>\
								</div>\
							</div>\
							<div class="rst-box-data">\
								<h4><a href="product-single.html">Run road</a></h4>\
								<div class="rst-box-metadata">\
									<div class="rst-meta"><span>20 articles</span></div>\
									<div class="rst-meta"><span>web design</span></div>\
									<div class="clear"></div>\
								</div>\
							</div>\
						</div>\
					</div>\
					<div class="col-sm-4">\
						<div class="rst-product-box">\
							<div class="rst-box-image">\
								<img alt="" src="http://placehold.it/370x450">\
								<div class="rst-box-overlay ">\
									<a class="btn btn-primary" href="#">start support</a>\
									<a class="btn btn-success" href="#">live chat</a>\
								</div>\
							</div>\
							<div class="rst-box-data">\
								<h4><a href="product-single.html">Run road</a></h4>\
								<div class="rst-box-metadata">\
									<div class="rst-meta"><span>20 articles</span></div>\
									<div class="rst-meta"><span>web design</span></div>\
									<div class="clear"></div>\
								</div>\
							</div>\
						</div>\
					</div>\
				';load_more.parents('.tab-pane').find('.row').append(data);jQuery(' .rst-box-image ').each(function(){jQuery(this).hoverdir();});},3000);});$('.rst-menu-trigger').on('click',function(){$(this).toggleClass('exit').parent().find('.rst-main-menu ul').slideToggle(700);});jQuery('.rst-form-close').on('click',function(e){e.preventDefault();jQuery('.rst-login form').slideUp('fast')});});jQuery(window).scroll(function(){header_sticky();});jQuery(window).load(function(){if(jQuery(window).width()>768){letsticky=1;}header_sticky();jQuery('#loader-wrapper').animate({opacity:0,},1000,'swing',function(){jQuery('#loader-wrapper').css('display','none');});menu();menubar_height();if(jQuery('.rst-chat-content').length>0){jQuery('.rst-chat-content').mCustomScrollbar({});}jQuery(' .rst-box-image ').each(function(){jQuery(this).hoverdir();});});jQuery(window).resize(function(){menubar_height();if(jQuery(window).width()<769){letsticky=0;jQuery('.rst-header-menu-bar').removeClass('rst-sticky');}else{letsticky=1;header_sticky();}});}());}main();