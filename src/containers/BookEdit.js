import React from "react";
import {
  Edit,
  SimpleForm,
  TextInput,
  ImageInput,
  ImageField
} from "react-admin";

export const BookEdit = props => (
  <Edit {...props}>
    <SimpleForm>
      <TextInput disabled source="bookID" fullWidth />
      <TextInput source="title" label="Tựa sách" fullWidth />
      <ImageInput source="picture" label="Hình ảnh" accept="image/*">
        <ImageField source="src" title="title" />
      </ImageInput>
      <TextInput source="author" label="Tác giả" fullWidth />
      <TextInput source="aboutBook" label="Mô tả" fullWidth />
      <TextInput source="qty" label="Số lượng" fullWidth />
      <TextInput source="price" label="Giá" fullWidth />
    </SimpleForm>
  </Edit>
);
