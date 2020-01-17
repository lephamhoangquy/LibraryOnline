import React from "react";
import {
  List,
  Datagrid,
  TextField,
  NumberField,
  DateField,
  EditButton,
  DeleteButton,
  Filter,
  TextInput
} from "react-admin";

const PostFilter = props => (
  <Filter {...props}>
    <TextInput label="Search" source="title" alwaysOn />
  </Filter>
);

export const BookList = props => {
  return (
    <List filters={<PostFilter />} {...props}>
      <Datagrid>
        <TextField source="title" label="Tưạ sách" />
        <TextField source="author" label="Tác giả" />
        <TextField source="aboutBook" label="Mô tả" />
        <NumberField source="qty" label="Số lượng" />
        <DateField source="createdAt" label="Ngày thêm" />
        <NumberField source="price" label="Giá" />
        <EditButton />
        <DeleteButton />
      </Datagrid>
    </List>
  );
};
