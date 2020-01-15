go
create type dbo.DonHangDuocChon
as table (
	BookID int,
	Qty int
)
go
create proc sp_BuyBook
	@DanhSachDonHang as dbo.DonHangDuocChon readonly,
	@Email varchar(100),
	@Address nvarchar(1000)
as
begin
	declare @LENGTH INT
	declare @COUNTER INT
	declare @TOTALPRICE FLOAT
	declare @BOOKID INT
	DECLARE @QTY INT
	DECLARE @CURRENTQTY INT
	DECLARE @NEWQTY INT
	DECLARE @PRICEOFBOOK FLOAT
	DECLARE @FINALCARDID INT
	SET @LENGTH = 0
	SET @COUNTER = 0
	SET @TOTALPRICE = 0

	BEGIN TRAN

	SET @LENGTH = (SELECT COUNT(BOOKID) FROM @DanhSachDonHang)
	WHILE (@LENGTH > 0)
	BEGIN
		SELECT @BOOKID = BookID, @QTY = Qty from @DanhSachDonHang order by BookID OFFSET @Counter ROWS FETCH FIRST 1 ROW ONLY
		IF (EXISTS (SELECT BOOKID FROM Book WHERE BookID=@BOOKID))
		BEGIN
			SELECT @CURRENTQTY=QTY, @PRICEOFBOOK=Price FROM Book WHERE BookID=@BOOKID
			IF (@CURRENTQTY >= @QTY)
			BEGIN
				SET @NEWQTY = @CURRENTQTY - @QTY
				UPDATE Book
				SET Qty=@NEWQTY
				WHERE BookID=@BOOKID

				SET @TOTALPRICE = @TOTALPRICE + @QTY*@PRICEOFBOOK

			END
			ELSE
			BEGIN
				 RAISERROR ('The number of books is not enough', -- Message text.  
							   1, -- Severity.  
							   1 -- State.  
							);  
				rollback
				return
			END
		END
		ELSE
		BEGIN
			 RAISERROR ('Some book is not exist', -- Message text.  
							   1, -- Severity.  
							   1 -- State.  
							);  
			rollback
			return
		END
		SET @COUNTER += 1;
		SET @LENGTH -= 1;
	END

	INSERT INTO Cards(EMAIL,TotalPrice,AddressDeliver,CreatedAt)
	values (@Email,@TOTALPRICE,@Address,GETDATE())

	SELECT TOP 1 @FINALCARDID=CARDID FROM Cards ORDER BY CardID DESC
	SET @LENGTH = (SELECT COUNT(BOOKID) FROM @DanhSachDonHang)
	SET @COUNTER = 0
	WHILE (@LENGTH > 0)
	BEGIN
		SELECT @BOOKID = BookID, @QTY = Qty from @DanhSachDonHang order by BookID OFFSET @Counter ROWS FETCH FIRST 1 ROW ONLY
		INSERT INTO Cards_Book(CardID,BookID,Qty)
		VALUES (@FINALCARDID,@BOOKID,@QTY)
		SET @COUNTER += 1;
		SET @LENGTH -= 1;
	END


	COMMIT TRAN
	RETURN
end
