import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import dotenv from 'dotenv';
import React from "react";
import PessoaList from "./screens/PessoaList";

dotenv.config();

export default function App() {
  return <PessoaList />;
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
