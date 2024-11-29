﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="ChiTietMatHang.aspx.cs" Inherits="btlltw.ChiTietMatHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
		<div class="row">
			<img src="images/hat4.jpg" width="100%" height="auto" alt="" style="min-height: 300px">
		</div>
	</div>
	<br>
	<div class="container">
		<div class="row">
			<div class="chitietanh">	
				<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6" id="imgProduct" runat="server">

				</div>
				<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
					<h2 id="titleProduct" runat="server"></h2>
					<div class="">
						<i class="fa fa-star" aria-hidden="true"></i>
						<i class="fa fa-star" aria-hidden="true"></i>
						<i class="fa fa-star" aria-hidden="true"></i>		
						<i class="fa fa-star-half-o" aria-hidden="true"></i>
						<i class="fa fa-star-o" aria-hidden="true"></i>
					</div>
					<span id="priceProduct" runat="server"></span>
					
					<hr>
					<div class="row">
						<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
							<p>Kích thước</p>
							<button class="btn btn-default">XS</button>
							<button class="btn btn-default">S</button>
							<button class="btn btn-default">M</button>
							<button class="btn btn-default">L</button>
						</div>
						<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
							<p>Màu sắc</p>
							<button class="btn btn-default" style="background-color: green;" color: white >Xanh </button>
							<button class="btn btn-default" style="background-color: red" color: white>Đỏ</button>
							<button class="btn btn-default" style="background-color: purple"color: white>Tím</button>
							<button class="btn btn-default" style="background-color: yellow"color: white>Vàng</button>
						</div>
					</div>
					<hr>
					<div class="row">
						<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" id="btns" runat="server">

						</div>
					</div>

				</div>
			</div>

		</div>
	</div>
	<div class="container">
		<div class="row">
			<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
				<div class="motasp">
					<div class="row">
						<div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
							<h3> MÔ TẢ SẢN PHẨM</h3>
							<hr>
							<ul>
								<li><b>Chất liệu:</b>Sứ làm từ đất sét sông Hồng</li>
								<li><b>Khối lượng:</b>0.5kg</li>
								<li><b>Thương hiệu:</b>VietNamBatTrang</li>
								<li><b>Mã sản phẩm:</b>BPT2</li>
								<li><b>Công dụng:</b>Có rất nhiều công dụng như đựng canh , đựng nước , Trang trí phòng , bát có màu nâu phù hợp cho những người mệnh thổ</li>
								<li><b>Bộ sản phẩm bao gồm:</b>1 Sản phẩm</li>
							</ul>
						</div>
						<div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
							<h3>THÔNG TIN BẢO HÀNH</h3>
							<hr>
							<ul>
								<li><i class="fa fa-thumbs-up" aria-hidden="true"></i>

								100% Chính hãng</li>
								<li><i class="fa fa-repeat" aria-hidden="true"></i>
								7 ngày đổi trả dễ dàng</li>
								<li><i class="fa fa-shield" aria-hidden="true"></i>
								Áp dụng chính sách bảo hành 6 tháng</li>
							</ul>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="container">
		<div class="row">
				<hr>
				<Center><h3>SẢN PHẨM TƯƠNG TỰ</h3></Center>
			<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" id="listProductTT" runat="server">
								
			</div>
		</div>
	</div>
	<br>
</asp:Content>