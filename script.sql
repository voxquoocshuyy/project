create table Project.HocVien
(
    MaHV  int auto_increment
        primary key,
    TenHV varchar(255) null,
    Lop   varchar(3)   null,
    constraint MaHV
        unique (MaHV)
);

create table Project.MonHoc
(
    MaMH  int auto_increment
        primary key,
    TenMH varchar(255) null,
    constraint MaMH
        unique (MaMH)
);

create table Project.BangDiem
(
    MaHP   int auto_increment
        primary key,
    Diem   float null,
    HeSo   int   null,
    NamHoc int   null,
    MaHV   int   null,
    MaMH   int   null,
    constraint MaHP
        unique (MaHP),
    constraint BangDiem_HocVien_MaHV_fk
        foreign key (MaHV) references Project.HocVien (MaHV),
    constraint BangDiem_MonHoc_MaMH_fk
        foreign key (MaMH) references Project.MonHoc (MaMH)
);

 /* Cau 2b. */
select hv.MaHV, hv.TenHV, mh.TenMH, (sum(bd.Diembd.HeSo)/sum(bd.HeSo)) as DiemTBMon 
from BangDiem bd 
join HocVien hv on hv.MaHV = bd.MaHV
join MonHoc mh on bd.MaMH = mh.MaMH
where bd.NamHoc = '2023'
group by hv.MaHV, hv.TenHV, mh.TenMH
having (SUM(bd.Diem bd.HeSo) / SUM(bd.HeSo)) < 5.0
order by hv.MaHV, mh.TenMH

 /* Cau 2c. */
select HocVien.MaHV, HocVien.TenHV, AVG(DiemTBMon) AS DiemTBNH, '2023' AS NamHoc
from HocVien
join (
    select MaHV, MaMH, (SUM(Diem * HeSo) / SUM(HeSo)) AS DiemTBMon
    from BangDiem
    where NamHoc = '2023'
    group by MaHV, MaMH
) AS DiemTB ON HocVien.MaHV = DiemTB.MaHV
group by HocVien.MaHV, HocVien.TenHV, HocVien.Lop
having HocVien.Lop = '7A1'
order by DiemTBNH DESC

