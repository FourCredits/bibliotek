{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  nativeBuildInputs = with pkgs; [
    dotnetCorePackages.sdk_9_0
  ];
}
